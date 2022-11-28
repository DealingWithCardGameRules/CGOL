using CardGameWebApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using CardGameWebApp.Shared.Responses;
using System;
using CardGameWebApp.Shared.DTOs;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using System.Collections.Generic;
using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using System.Linq;
using System.Dynamic;
using CardGameWebApp.Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using dk.itu.game.msc.cgol.Representation;
using Microsoft.Extensions.Primitives;
using dk.itu.game.msc.cgol.Distribution;
using Agents;
using dk.itu.game.msc.cgol;

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly SessionServiceWrapper session;
        private readonly IHubContext<GameHub> gameHub;

        public GameController(SessionServiceWrapper session, IHubContext<GameHub> gameHub)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
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
            session.Create(sessionId, new WebContext { User = "anonymous" });
            var current = session.GetSession(sessionId);
            current.Service.Parse(game.CGOLSource);
            return Created(Url.Action(nameof(GetGame), "game", new { id = sessionId }, Request.Scheme), null);
        }

        [HttpPost("{id:Guid}")]
        public async Task<ActionResult> ExtendGame(Guid id, [FromBody] CreateGameDTO game)
        {
            var current = session.GetSession(id);
            if (current == null)
                return NotFound("Session not found");

            try
            {
                current.Service.Parse(game.CGOLSource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            await gameHub.Clients.Group(id.ToString()).SendAsync("NewState");

            return Ok();
        }

        [HttpGet("{id:Guid}")]
        public async Task<GameOverviewResponse> GetGame(Guid id)
        {
            async Task<IDictionary<string, string>> colLink(IAsyncEnumerable<string> names)
            {
                Dictionary<string, string> output = new();
                await foreach (var name in names)
                    output[name] = Url.Action(nameof(GetCollection), "game", new { id, name }, Request.Scheme);
                return output;
            }

            var current = session.GetSession(id);
            var zones = (await current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "community" } }))();
            zones = zones.Union((await current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "zone" } }))());

            var dto = new GameStateDTO
            {
                NumberOfPlayers = await current.Service.Dispatch(new GetNumberOfPlayers()),
                Decks = await colLink((await current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "deck" } }))()),
                Hands = await colLink((await current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "hand" } }))()),
                Zones = await colLink(zones)
            };

            var response = new GameOverviewResponse(Request.GetEncodedUrl())
            {
                Game = dto,
                SessionId = id
            };
            response.Links.Add("actions", Url.Action(nameof(GetActions), "game", new { id }, Request.Scheme));
            response.Links.Add("hub", $"{Request.Scheme}://{Request.Host}/gamehub");
            response.Links.Add("random-action", Url.Action(nameof(PerformRandomAction), "game", new { id }, Request.Scheme));

            return response;
        }

        [HttpGet("{id:Guid}/collections/{name}")]
        public async Task<CardCollectionResponse> GetCollection(Guid id, string name)
        {
            var current = session.GetSession(id);
            List<IUserAction> colActions = new();
            List<IUserAction> cardActions = new();

            var playerIndexes = GetPlayerIndexes(current, Request.Headers["clientid"]);

            foreach (var playerIndex in playerIndexes)
            {
                await foreach (var action in (await current.Service.Dispatch(new GetAvailableActionsForCollection(name, playerIndex)))())
                {
                    if (action.Command.GetPlayCard() != null)
                        cardActions.Add(action);
                    colActions.Add(action);
                }
            }

            async IAsyncEnumerable<CardRefDTO> cardLink(IEnumerable<ICard> cards)
            {
                foreach (var card in cards)
                {
                    yield return new CardRefDTO
                    {
                        Name = card.Template,
                        Instance = card.Instance,
                        //Link = Url.Action(nameof(GetCard), "game", new { id, card = card.Instance }, Request.Scheme),
                        Actions = await ActionLink(cardActions.ToAsyncEnumerable(), id, card.Instance)
                    };
                }
            }

            var dto = new CardCollectionDTO
            {
                Name = name,
                VisibleCards = cardLink((await current.Service.Dispatch(new GetVisibleCards(name, playerIndexes)))().ToEnumerable()).ToEnumerable(),
                CardCount = await current.Service.Dispatch(new CardCount(name)),
                Tags = (await current.Service.Dispatch(new GetCollectionTags(name)))().ToEnumerable(),
                Actions = await ActionLink(colActions.ToAsyncEnumerable(), id)
            };
            
            return new CardCollectionResponse(Request.GetEncodedUrl())
            {
                CardCollection = dto
            };
        }

        private async Task<IDictionary<string, string>> ActionLink(IAsyncEnumerable<IUserAction> commands, Guid id, Guid? card = null)
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            await foreach (var command in commands)
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

        [HttpGet("{id:Guid}/cards/{card:Guid}")]
        public ActionResult GetCard(Guid id, Guid card)
        {
            return Ok();
        }

        [HttpGet("{id:Guid}/actions/{instance:Guid}")]
        public async Task<ActionResult<ActionResponse>> GetAction(Guid id, Guid instance)
        {
            var current = session.GetSession(id);
            
            ICommand command = null;
            var playerIndexes = GetPlayerIndexes(current, Request.Headers["clientid"]);
            foreach (var playerIndex in playerIndexes)
            {
                var cmd = await current.Service.Dispatch(new GetAvailableAction(instance, playerIndex));
                if (cmd != null)
                {
                    command = cmd;
                    break;
                }
            }
                
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

        [HttpPost("{id:Guid}/actions/random")]
        public async Task<ActionResult> PerformRandomAction(Guid id)
        {
            var current = session.GetSession(id);
            var agent = new AIAgentFactory().CreateRandom();
            current.Service.Dispatch(await agent.Choose(current.Service.SessionEvents.ToArray()) );
            await gameHub.Clients.Group(id.ToString()).SendAsync("NewState");
            return Ok();
        }

        [HttpPost("{id:Guid}/actions/{instance:Guid}")]
        public async Task<ActionResult> PerformAction(Guid id, Guid instance, [FromBody]ActionDTO action)
        {
            var current = session.GetSession(id);
            ICommand command = null;
            var playerIndexes = GetPlayerIndexes(current, Request.Headers["clientid"]);
            foreach (var playerIndex in playerIndexes)
            {
                var cmd = await current.Service.Dispatch(new GetAvailableAction(instance, playerIndex));
                if (cmd != null)
                {
                    command = cmd;
                    break;
                }
            }

            if (command == null)
                return NotFound(); // Early out

            var playCardProperty = command.GetPlayCard();
            if (playCardProperty != null)
            {
                var value = action.Parameters.Single(p => p.Name.Equals(playCardProperty)).Value;
                if (value != null)
                {
                    var cardId = Guid.Parse(value);
                    command.SetPlayCard(cardId);
                }
            }

            current.Service.Dispatch(command);
            await gameHub.Clients.Group(id.ToString()).SendAsync("NewState");
            return Ok();
        }

        [HttpGet("{id:Guid}/actions")]
        public async Task<ActionListResponse> GetActions(Guid id)
        {
            var current = session.GetSession(id);
            var playerIndexes = GetPlayerIndexes(current, Request.Headers["clientid"]);
            var actions = GetActions(current, playerIndexes);

            return new ActionListResponse(Request.GetEncodedUrl())
            {
                Actions = await ActionLink(actions, id)
            };
        }

        private IEnumerable<int> GetPlayerIndexes(Session session, StringValues stringValues)
        {
            var clientIds = Request.Headers["clientid"].ToString().CommaSeperateTrimmed();
            foreach (var clientId in clientIds)
                foreach (var index in session.PlayerRepository.GetIndexes(clientId))
                    yield return index;
        }

        private async IAsyncEnumerable<IUserAction> GetActions(Session session, IEnumerable<int> playerIndexes)
        {
            foreach (var playerIndex in playerIndexes)
            {
                var actions = (await session.Service.Dispatch(new GetAvailableActions(playerIndex)))();
                await foreach (var action in actions)
                {
                    yield return action;
                }
            }
        }
    }
}
