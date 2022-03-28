using CardGameWebApp.Shared;
using dk.itu.game.msc.cgdl;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Representation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemosController : Controller
    {
        readonly private string deck = "deck";
        readonly private string hand = "hand";
        readonly private string discardPile = "discardPile";

        private readonly SessionRepository repository;
        private readonly SessionFactory factory;

        public DemosController(SessionRepository repository, SessionFactory factory)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        [HttpGet]
        public DemoList Index()
        {
            var demos = new DemoList(Request.GetEncodedUrl());
            demos.Links.Add("Draw one play one", Url.Action("create", "demos", new { game = "d1p1" }, Request.Scheme));
            return demos;
        }

        [HttpGet("game")]
        public IActionResult Create(string game)
        {
            // Only support draw one play one demo
            if (game != "d1p1")
                return NotFound(game);

            var id = Guid.NewGuid();
            var session = factory.Create(id);
            repository.AddSession(session);
            return Created(Url.Action("SetupD1P1", "demos", new { id }, Request.Scheme), null);
        }

        [HttpGet("{id:Guid}")]
        public Draw1play1DemoDTO SetupD1P1(Guid id)
        {
            var service = GetService(id);

            // Setup
            service.Dispatch(new CreateDeck(deck));
            service.Dispatch(new CreateDeck(hand));
            service.Dispatch(new CreateDeck(discardPile));
            service.Dispatch(new CreateCard("Pass"));
            service.Dispatch(new AddCard("Pass", deck));

            return new Draw1play1DemoDTO
            {
                CardsInDeckQuery = Url.Action(nameof(Count), "demos", new { id, collection = deck }, Request.Scheme),
                CardsInHandQuery = Url.Action(nameof(GetCardsIn), "demos", new { id, collection = hand }, Request.Scheme),
                DrawAction = Url.Action(nameof(DrawCard), "demos", new { id }, Request.Scheme),
                TopCardInDiscardPileQuery = Url.Action(nameof(GetCardsIn), "demos", new { id, collection = discardPile, top = 1 }, Request.Scheme),
            };
        }

        [HttpGet("{id:Guid}/{collection}/count")]
        public int Count(Guid id, string collection)
		{
            var service = GetService(id);
            return service.Dispatch(new CardCount(collection));
        }

        [HttpGet("{id:Guid}/draw")]
        public IActionResult DrawCard(Guid id)
		{
            var service = GetService(id);
            service.Dispatch(new DrawCard(deck, hand));

            return Ok();
		}

        [HttpGet("{id:Guid}/play")]
        public IActionResult PlayCard(Guid id, [FromQuery] Guid card)
        {
            var service = GetService(id);
            service.Dispatch(new PlayCard(hand, discardPile, card));

            return Ok();
        }

        [HttpGet("{id:Guid}/{collection}")]
        public IEnumerable<CardDescriptionDTO> GetCardsIn(Guid id, string collection, int top = 0)
		{
            var service = GetService(id);

            var card = service.Dispatch(new GetTopCard(collection));
            var dto = new CardDescriptionDTO
            {
                Template = card.Template
            };
            if (collection == hand)
			{
                dto.Actions = new Dictionary<string, string> 
                { 
                    { "Play", Url.Action(nameof(PlayCard), "demos", new { id, card=card.Instance }, Request.Scheme) }
                };
			}

            yield return dto;
        }

        private CGDLService GetService(Guid id) => repository.GetSession(id).Service ?? throw new Exception();

        class PassCard : TagHandler, ICard
		{
			public PassCard()
			{
				Instance = Guid.NewGuid();
			}

			public Guid Instance { get; }

            public string Name => "Pass";

            public string Illustration => "Pass";

            public string Description => "Does nothing.";

            public string Template => throw new NotImplementedException();
        }
	}
}
