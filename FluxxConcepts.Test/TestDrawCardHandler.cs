using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Test
{
    [TestClass]
    public class TestDrawCardHandler
    {
        [TestMethod]
        public void DrawCardCommand_NoDispatcher_ThrowsArgumentNullException()
        {
            // Given
            IDispatcher dispatcher = null;

            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new DrawCardHandler(Substitute.For<ITimeProvider>(), dispatcher, new RecycleRules());
            });
        }

        [TestMethod]
        public void Handle_HasCardsReturnsTrue_DispatchesCardDrawnEvent()
        {
            // Given
            var dispatcher = Substitute.For<IDispatcher>();
            var timeProvider = Substitute.For<ITimeProvider>();
            var sut = new DrawCardHandler(timeProvider, dispatcher, new RecycleRules());
            var command = new DrawCard(string.Empty, string.Empty);
            var eventDispatcher = Substitute.For<IEventDispatcher>();

            dispatcher.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // When
            sut.Handle(command, eventDispatcher);

            // Then
            eventDispatcher.Received().Dispatch(Arg.Any<CardDrawn>());
        }

        [TestMethod]
        public void Handle_SpecificSource_CardDrawnSourceMatches()
        {
            // Given
            var dispatcherStub = Substitute.For<IDispatcher>();
            var timeProvider = Substitute.For<ITimeProvider>();
            var sut = new DrawCardHandler(timeProvider, dispatcherStub, new RecycleRules());
            var expectedSource = "Deck";
            var command = new DrawCard(expectedSource, string.Empty);
            var eventDispatcherMock = Substitute.For<IEventDispatcher>();

            dispatcherStub.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // When
            sut.Handle(command, eventDispatcherMock);

            // Then
            eventDispatcherMock.Received().Dispatch(Arg.Is<CardDrawn>(result => expectedSource == result.Source));
        }

        [TestMethod]
        public void Handle_SpecificTarget_CardDrawnTargetMatches()
        {
            // Given
            var dispatcherStub = Substitute.For<IDispatcher>();
            var timeProvider = Substitute.For<ITimeProvider>();
            var sut = new DrawCardHandler(timeProvider, dispatcherStub, new RecycleRules());
            var expectedDestination = "Deck";
            var command = new DrawCard(string.Empty, expectedDestination);
            var eventDispatcherMock = Substitute.For<IEventDispatcher>();

            dispatcherStub.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // When
            sut.Handle(command, eventDispatcherMock);

            // Then
            eventDispatcherMock.Received().Dispatch(Arg.Is<CardDrawn>(result => expectedDestination == result.Distination));
        }
    }
}
