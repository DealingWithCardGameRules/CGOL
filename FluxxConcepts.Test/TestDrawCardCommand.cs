using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Test
{
    [TestClass]
    public class TestDrawCardCommand
    {
        [TestMethod]
        public void DrawCardCommand_NoDispatcher_ThrowsArgumentNullException()
        {
            // Given
            IDispatcher dispatcher = null;

            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new DrawCardCommandHandler(dispatcher);
            });
        }

        [TestMethod]
        public void Handle_Any_CallsHasCardsForSource()
        {
            // Given
            var dispatcher = Substitute.For<IDispatcher>();
            var sut = new DrawCardCommandHandler(dispatcher);
            var command = new DrawCardCommand(Guid.Empty, Guid.Empty);

            dispatcher.Dispatch(Arg.Any<HasCards>()).Returns(true);

            // Given
            sut.Handle(command, Substitute.For<IEventDispatcher>());

            // Then
            dispatcher.Received().Dispatch(Arg.Any<HasCards>());
        }
    }
}
