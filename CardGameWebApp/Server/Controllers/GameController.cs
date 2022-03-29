using CardGameWebApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using CardGameWebApp.Shared.Responses;
using System;
using dk.itu.game.msc.cgdl.Representation;
using CardGameWebApp.Shared.DTOs;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System.Collections.Generic;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System.Linq;
using System.Dynamic;
using CardGameWebApp.Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly SessionService session;
        private readonly IUserEnquirerFactory userEnquirerFactory;
        private readonly IHubContext<GameHub> gameHub;

        public GameController(SessionService session, IUserEnquirerFactory userEnquirerFactory, IHubContext<GameHub> gameHub)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
            this.userEnquirerFactory = userEnquirerFactory ?? throw new ArgumentNullException(nameof(userEnquirerFactory));
            this.gameHub = gameHub ?? throw new ArgumentNullException(nameof(gameHub));
        }

        [HttpGet]
        public GameIndexResponse Index()
        {
            return new GameIndexResponse(Request.GetEncodedUrl())
            {
                Game = new CreateGameDTO()
            };
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateGameDTO game)
        {
            var sessionId = Guid.NewGuid();
            session.Create(sessionId, userEnquirerFactory);
            var current = session.GetSession(sessionId);
            current.Service.Parse(game.CGDLSource);
            return Created(Url.Action(nameof(GetGame), "game", new { id = sessionId }, Request.Scheme), null);
        }

        [HttpGet("{id:Guid}")]
        public GameOverviewResponse GetGame(Guid id)
        {
            IDictionary<string, string> colLink(IEnumerable<string> names)
            {
                Dictionary<string, string> output = new Dictionary<string, string>();
                foreach (var name in names)
                {
                    output[name] = Url.Action(nameof(GetCollection), "game", new { id, name }, Request.Scheme);
                }
                return output;
            }

            var current = session.GetSession(id);
            var dto = new GameStateDTO
            {
                NumberOfPlayers = current.Service.Dispatch(new GetNumberOfPlayers()),
                Decks = colLink(current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "deck" } })),
                Hands = colLink(current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "hand" } })),
                Community = colLink(current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "community" } }))
            };

            var response = new GameOverviewResponse(Request.GetEncodedUrl())
            {
                Game = dto,
                SessionId = id
            };
            //response.Links.Add("actions", Url.Action(nameof(GetActions), "game", new { id }, Request.Scheme));
            response.Links.Add("hub", $"{Request.Scheme}://{Request.Host}/gamehub");

            return response;
        }

        [HttpGet("{id:Guid}/collections/{name}")]
        public CardCollectionResponse GetCollection(Guid id, string name)
        {
            var current = session.GetSession(id);
            List<IUserCommand> colActions = new List<IUserCommand>();
            List<IUserCommand> cardActions = new List<IUserCommand>();

            foreach (var action in current.Service.Dispatch(new GetAvailableActionsForCollection(name)))
            {
                if (action.Command.GetPlayCard() != null)
                    cardActions.Add(action);
                else
                    colActions.Add(action);
            }

            IEnumerable<CardRefDTO> cardLink(IEnumerable<ICard> cards)
            {
                foreach (var card in cards)
                {
                    yield return new CardRefDTO
                    {
                        Name = card.Template,
                        //Link = Url.Action(nameof(GetCard), "game", new { id, card = card.Instance }, Request.Scheme),
                        Actions = actionLink(cardActions, card.Instance)
                    };
                }
            }

            IDictionary<string, string> actionLink(IEnumerable<IUserCommand> commands, Guid? card = null)
            {
                Dictionary<string, string> output = new Dictionary<string, string>();
                foreach (var command in commands)
                {
                    dynamic obj = new ExpandoObject();
                    obj.id = id;
                    obj.instance = command.Command.Instance;
                    if (card != null)
                        (obj as IDictionary<string, object>).Add(command.Command.GetPlayCard(), card);

                    output[command.Label] = Url.Action(nameof(GetAction), "game", (object)obj, Request.Scheme);
                }
                return output;
            }

            var dto = new CardCollectionDTO
            {
                Name = name,
                VisibleCards = cardLink(current.Service.Dispatch(new GetVisibleCards(name))),
                CardCount = current.Service.Dispatch(new CardCount(name)),
                Tags = current.Service.Dispatch(new GetCollectionTags(name)),
                Actions = actionLink(colActions)
            };
            
            return new CardCollectionResponse(Request.GetEncodedUrl())
            {
                CardCollection = dto
            };
        }

        [HttpGet("{id:Guid}/cards/{card:Guid}")]
        public ActionResult GetCard(Guid id, Guid card)
        {
            return Ok();
        }

        [HttpGet("{id:Guid}/actions/{instance:Guid}")]
        public ActionResult<ActionResponse> GetAction(Guid id, Guid instance)
        {
            var current = session.GetSession(id);
            var command = current.Service.Dispatch(new GetAvailableAction(instance));
            if (command == null)
                return NotFound(); // Early out

            var dto = new ActionDTO();
            var parameters = new List<ActionParameterDTO>();

            var playCardProperty = command.GetPlayCard();
            if (playCardProperty != null)
            {
                parameters.Add(new ActionParameterDTO
                {
                    Name = playCardProperty,
                    Type = "CardID",
                    Value = Request.Query[playCardProperty]
                });
            }

            dto.Parameters = parameters;
            var output = new ActionResponse(dto, Request.GetEncodedUrl());
            return output;
        }

        [HttpPost("{id:Guid}/actions/{instance:Guid}")]
        public async Task<ActionResult> PerformAction(Guid id, Guid instance, [FromBody]ActionDTO action)
        {
            var current = session.GetSession(id);
            var command = current.Service.Dispatch(new GetAvailableAction(instance));
            if (command == null)
                return NotFound(); // Early out

            var playCardProperty = command.GetPlayCard();
            if (playCardProperty != null)
            {
                var value = action.Parameters.Single(p => p.Name.Equals(playCardProperty)).Value;
                var cardId = Guid.Parse(value);
                command.SetPlayCard(cardId);
            }

            current.Service.Dispatch(command);
            await gameHub.Clients.Group(id.ToString()).SendAsync("NewState");
            return Ok();
        }

        [HttpGet("{id:Guid}/actions")]
        public ActionResult GetActions(Guid id)
        {
            var current = session.GetSession(id);
            var actions = current.Service.Dispatch(new GetAvailableActions());
            return Ok();
        }
    }
}
