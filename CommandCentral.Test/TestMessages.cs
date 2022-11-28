using dk.itu.game.msc.cgol.Distribution;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommandCentral.Test
{
    [TestClass]
    public class TestMessages
    {

        [TestMethod]
        public void Instantiate_MissingServiceProvider_ThrowsArgumentNullException()
        {
            // Given
            IServiceProvider service = null;

            // When
            Assert.ThrowsException<ArgumentNullException>(() => {
                new MessageDispatcher(service, Substitute.For<IEventDispatcher>());
                });
        }

        [TestMethod]
        public void Instantiate_MissingEventDispatcher_ThrowsArgumentNullException()
        {
            // Given
            IEventDispatcher dispatcher = null;

            // When
            Assert.ThrowsException<ArgumentNullException>(() => {
                new MessageDispatcher(Substitute.For<IServiceProvider>(), dispatcher);
            });
        }

        [TestMethod]
        public async Task Dispatch_NoCommandHandler_ThrowsHandlerMissingException()
        {
            // Given
            var providerStub = Substitute.For<IServiceProvider>();
            var sut = new MessageDispatcher(providerStub, Substitute.For<IEventDispatcher>());
            var someCommandStub = Substitute.For<ICommand>();

            // When
            await Assert.ThrowsExceptionAsync<HandlerMissingException>(async () =>
            {
                await sut.Dispatch(someCommandStub);
            });
        }

        [TestMethod]
        public async Task Dispatch_AnyCommand_CallsGetService()
        {
            // Given
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = new MessageDispatcher(providerMock, Substitute.For<IEventDispatcher>());
            
            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<ICommandHandler<ICommand>>());

            // When
            await sut.Dispatch(Substitute.For<ICommand>());

            // Then
            providerMock.Received().GetService(Arg.Any<Type>());
        }

        [TestMethod]
        public async Task Dispatch_SpecificCommand_CallsGetServiceWithSpecificHandler()
        {
            // Given
            var commandStub = new CommandStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = new MessageDispatcher(providerMock, Substitute.For<IEventDispatcher>());

            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<ICommandHandler<ICommand>>());

            // When
            await sut.Dispatch(commandStub);

            // Then
            providerMock.Received().GetService(typeof(ICommandHandler<CommandStub>));
        }

        [TestMethod]
        public async Task Dispatch_KnownCommand_CallsHandleOnCommandHandlerWithCommand()
        {
            // Given
            var commandStub = new CommandStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var commandHandlerMock = Substitute.For<ICommandHandler<ICommand>>();
            var sut = new MessageDispatcher(providerMock, Substitute.For<IEventDispatcher>());

            providerMock.GetService(Arg.Any<Type>()).Returns(commandHandlerMock);

            // When
            await sut.Dispatch(commandStub);

            // Then
            await commandHandlerMock.Received().Handle(commandStub, Arg.Any<IEventDispatcher>());
        }

        [TestMethod]
        public async Task Dispatch_NoQueryHandler_ThrowsRuntimeBinderException()
        {
            // Given
            var queryStub = Substitute.For<IQuery<int>>();
            var sut = new MessageDispatcher(Substitute.For<IServiceProvider>(), Substitute.For<IEventDispatcher>());

            // When
            await Assert.ThrowsExceptionAsync<RuntimeBinderException>(async () =>
            {
                await sut.Dispatch(queryStub);
            });
        }

        [TestMethod]
        public async Task Dispatch_AnyQuery_CallsGetService()
        {
            // Given
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = new MessageDispatcher(providerMock, Substitute.For<IEventDispatcher>());

            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<IQueryHandler<IQuery<int>, int>>());

            // When
            await sut.Dispatch(Substitute.For<IQuery<int>>());

            // Then
            providerMock.Received().GetService(Arg.Any<Type>());
        }

        [TestMethod]
        public async Task Dispatch_SpecificQuery_CallsGetServiceWithSpecificHandler()
        {
            // Given
            var queryStub = new QueryStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = new MessageDispatcher(providerMock, Substitute.For<IEventDispatcher>());

            providerMock.GetService(typeof(IQueryHandler<QueryStub, int>)).Returns(Substitute.For< IQueryHandler<IQuery<int>, int> >());

            // When
            await sut.Dispatch(queryStub);

            // Then
            providerMock.Received().GetService(typeof(IQueryHandler<QueryStub, int>));
        }

        [TestMethod]
        public async Task Dispatch_KnownQuery_CallsHandleOnQueryHandlerWithQuery()
        {
            // Given
            var queryStub = new QueryStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var queryHandler = Substitute.For<IQueryHandler<IQuery<int>, int>>();
            var sut = new MessageDispatcher(providerMock, Substitute.For<IEventDispatcher>());

            providerMock.GetService(typeof(IQueryHandler<QueryStub, int>)).Returns(queryHandler);

            // When
            await sut.Dispatch(queryStub);

            // Then
            await queryHandler.Received().Handle(queryStub);
        }

        [TestMethod]
        public async Task Dispatch_KnownQuery_ReturnsValueFromQueryHandler()
        {
            // Given
            var expected = 42;
            var queryStub = new QueryStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var queryHandler = Substitute.For<IQueryHandler<IQuery<int>, int>>();
            var sut = new MessageDispatcher(providerMock, Substitute.For<IEventDispatcher>());

            providerMock.GetService(typeof(IQueryHandler<QueryStub, int>)).Returns(queryHandler);
            queryHandler.Handle(queryStub).Returns(expected);

            // When
            var result = await sut.Dispatch(queryStub);

            // Then
            Assert.AreEqual(expected, result);
        }

        // Dummy classes for test
        public class CommandStub : ICommand
        {
            public Guid ProcessId => throw new NotImplementedException();

            public Guid Instance => throw new NotImplementedException();
        }

        public class QueryStub : IQuery<int> { }

        public class EventStub : IEvent
        {
            public DateTime EventTime => throw new NotImplementedException();
            public int Version => throw new NotImplementedException();
            public Guid ProcessId => throw new NotImplementedException();
        }
    }
}
