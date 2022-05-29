using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Test
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
                new DrawCardHandler(Substitute.For<ICommandHandler<DrawCard>>(), dispatcher);
            });
        }

        [TestMethod]
        public void Handle_DrawLimitNotReached_HandlerOfDecorateeIsCalled()
        {
            // Given
            var dispatcherStub = Substitute.For<IDispatcher>();
            var decorateeMock = Substitute.For<ICommandHandler<DrawCard>>();
            var sut = new DrawCardHandler(decorateeMock, dispatcherStub);
            var command = new DrawCard(string.Empty, string.Empty);

            dispatcherStub.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // When
            sut.Handle(command, null);

            // Then
            decorateeMock.Received().Handle(command, null);
        }
    }
}
