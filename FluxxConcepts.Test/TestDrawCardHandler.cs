using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Exceptions;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
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
                new DrawCardHandler(dispatcher);
            });
        }

        [TestMethod]
        public void Handle_HasCardsReturnsFalse_ThrowsNoCardsException()
        {
            // Given
            var dispatcher = Substitute.For<IDispatcher>();
            var sut = new DrawCardHandler(dispatcher);
            var command = new DrawCard(Guid.Empty, Guid.Empty);

            dispatcher.Dispatch(Arg.Any<HasCards>()).Returns(false);

            // When, Then
            Assert.ThrowsException<NoCardsException>(() =>
            {
                sut.Handle(command, Substitute.For<IEventDispatcher>());
            });
        }

        [TestMethod]
        public void Handle_HasCardsReturnsTrue_DispatchesCardDrawnEvent()
        {
            // Given
            var dispatcher = Substitute.For<IDispatcher>();
            var sut = new DrawCardHandler(dispatcher);
            var command = new DrawCard(Guid.Empty, Guid.Empty);
            var eventDispatcher = Substitute.For<IEventDispatcher>();

            dispatcher.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // When
            sut.Handle(command, eventDispatcher);

            // Then
            eventDispatcher.Received().Dispatch(Arg.Any<CardDrawn>());
        }

        [TestMethod]
        public void Handle_HasCardsReturnsTrue_DispatchesGetTopCardQuery()
        {
            // Given
            var dispatcherMock = Substitute.For<IDispatcher>();
            var sut = new DrawCardHandler(dispatcherMock);
            var command = new DrawCard(Guid.Empty, Guid.Empty);
            dispatcherMock.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // When
            sut.Handle(command, Substitute.For<IEventDispatcher>());

            // Then
            dispatcherMock.Received().Dispatch(Arg.Any<GetTopCard>());
        }

        [TestMethod]
        public void Handle_SpecificSource_CardDrawnSourceMatches()
        {
            // Given
            var dispatcherStub = Substitute.For<IDispatcher>();
            var sut = new DrawCardHandler(dispatcherStub);
            var expectedSource = Guid.NewGuid();
            var command = new DrawCard(expectedSource, Guid.Empty);
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
            var sut = new DrawCardHandler(dispatcherStub);
            var expectedDestination = Guid.NewGuid();
            var command = new DrawCard(Guid.Empty, expectedDestination);
            var eventDispatcherMock = Substitute.For<IEventDispatcher>();

            dispatcherStub.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // When
            sut.Handle(command, eventDispatcherMock);

            // Then
            eventDispatcherMock.Received().Dispatch(Arg.Is<CardDrawn>(result => expectedDestination == result.Distination));
        }

        [TestMethod]
        public void Handle_GetTopCardReturnsInstance_CardDrawnCardMatchesInstance()
        {
            // Given
            var dispatcherStub = Substitute.For<IDispatcher>();
            var sut = new DrawCardHandler(dispatcherStub);
            var command = new DrawCard(Guid.Empty, Guid.Empty);
            var eventDispatcherMock = Substitute.For<IEventDispatcher>();
            var expectedInstance = Guid.NewGuid();
            var CardStub = Substitute.For<ICard>();

            dispatcherStub.Dispatch(Arg.Any<HasCards>()).Returns(true);
            dispatcherStub.Dispatch(Arg.Any<GetTopCard>()).Returns(CardStub);
            _ = CardStub.Instance.Returns(expectedInstance);

            // When
            sut.Handle(command, eventDispatcherMock);

            // Then
            eventDispatcherMock.Received().Dispatch(Arg.Is<CardDrawn>(result => expectedInstance == result.Card));
        }
    }
}
