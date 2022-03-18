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

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly SessionService session;

        public GameController(SessionService session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
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
            session.Create(sessionId);
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
                Decks = colLink(current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "deck" } })),
                Hands = colLink(current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "hand" } })),
                Community = colLink(current.Service.Dispatch(new GetCollectionNames { WithTags = new[] { "community" } }))
            };

            var response = new GameOverviewResponse(Request.GetEncodedUrl())
            {
                Game = dto
            };
            response.Links.Add("actions", Url.Action(nameof(GetActions), "game", new { id }, Request.Scheme));

            return response;
        }

        [HttpGet("{id:Guid}/collections/{name}")]
        public CardCollectionResponse GetCollection(Guid id, string name)
        {
            IDictionary<string, string> cardLink(IEnumerable<ICard> cards)
            {
                Dictionary<string, string> output = new Dictionary<string, string>();
                foreach (var card in cards)
                {
                    output[card.Name] = Url.Action(nameof(GetCard), "game", new { id, card=card.Instance }, Request.Scheme);
                }
                return output;
            }
            IDictionary<string, string> actionLink(IEnumerable<ICommand> commands)
            {
                Dictionary<string, string> output = new Dictionary<string, string>();
                foreach (var command in commands)
                {
                    output[command.GetType().Name] = Url.Action(nameof(GetActions), "game", new { id, instance=command.Instance }, Request.Scheme);
                }
                return output;
            }

            var current = session.GetSession(id);
            var dto = new CardCollectionDTO
            {
                Name = name,
                VisibleCards = cardLink(current.Service.Dispatch(new GetVisibleCards(name))),
                CardCount = current.Service.Dispatch(new CardCount(name)),
                Tags = current.Service.Dispatch(new GetCollectionTags(name)),
                Actions = actionLink(current.Service.Dispatch(new GetAvailableActionsForCollection(name)))
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
        public ActionResult GetActions(Guid id, Guid instance)
        {
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
