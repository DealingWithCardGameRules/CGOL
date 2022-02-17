using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgdl.CommandCentral.Test
{
    [TestClass]
    public class TestMessages
    {
        DispatchFactory factory;

        public TestMessages()
        {
            factory = new DispatchFactory();
        }

        [TestMethod]
        public void Instantiate_MissingServiceProvider_ThrowsArgumentNullException()
        {
            // Given
            IServiceProvider service = null;

            // When
            Assert.ThrowsException<ArgumentNullException>(() => {
                factory.Create(service);
                });
        }

        [TestMethod]
        public void Dispatch_NoCommandHandler_ThrowsRuntimeBinderException()
        {
            // Given
            var providerStub = Substitute.For<IServiceProvider>();
            var sut = factory.Create(providerStub);
            var someCommandStub = Substitute.For<ICommand>();

            // When
            Assert.ThrowsException<RuntimeBinderException>(() =>
            {
                sut.Dispatch(someCommandStub);
            });
        }

        [TestMethod]
        public void Dispatch_AnyCommand_CallsGetService()
        {
            // Given
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = factory.Create(providerMock);
            
            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<ICommandHandler<ICommand>>());

            // When
            sut.Dispatch(Substitute.For<ICommand>());

            // Then
            providerMock.Received().GetService(Arg.Any<Type>());
        }

        [TestMethod]
        public void Dispatch_SpecificCommand_CallsGetServiceWithSpecificHandler()
        {
            // Given
            var commandStub = new CommandStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = factory.Create(providerMock);
            
            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<ICommandHandler<ICommand>>());

            // When
            sut.Dispatch(commandStub);

            // Then
            providerMock.Received().GetService(typeof(ICommandHandler<CommandStub>));
        }

        [TestMethod]
        public void Dispatch_KnownCommand_CallsHandleOnCommandHandlerWithCommand()
        {
            // Given
            var commandStub = new CommandStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var commandHandlerMock = Substitute.For<ICommandHandler<ICommand>>();
            var sut = factory.Create(providerMock);
            
            providerMock.GetService(Arg.Any<Type>()).Returns(commandHandlerMock);

            // When
            sut.Dispatch(commandStub);

            // Then
            commandHandlerMock.Received().Handle(commandStub, Arg.Any<IEventDispatcher>());
        }

        [TestMethod]
        public void Dispatch_NoQueryHandler_ThrowsRuntimeBinderException()
        {
            // Given
            var queryStub = Substitute.For<IQuery<int>>();
            var sut = factory.Create(Substitute.For<IServiceProvider>());

            // When
            Assert.ThrowsException<RuntimeBinderException>(() =>
            {
                sut.Dispatch(queryStub);
            });
        }

        [TestMethod]
        public void Dispatch_AnyQuery_CallsGetService()
        {
            // Given
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = factory.Create(providerMock);
            
            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<IQueryHandler<IQuery<int>, int>>());

            // When
            sut.Dispatch(Substitute.For<IQuery<int>>());

            // Then
            providerMock.Received().GetService(Arg.Any<Type>());
        }

        [TestMethod]
        public void Dispatch_SpecificQuery_CallsGetServiceWithSpecificHandler()
        {
            // Given
            var queryStub = new QueryStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = factory.Create(providerMock);
            
            providerMock.GetService(typeof(IQueryHandler<QueryStub, int>)).Returns(Substitute.For< IQueryHandler<IQuery<int>, int> >());

            // When
            sut.Dispatch(queryStub);

            // Then
            providerMock.Received().GetService(typeof(IQueryHandler<QueryStub, int>));
        }

        [TestMethod]
        public void Dispatch_KnownQuery_CallsHandleOnQueryHandlerWithQuery()
        {
            // Given
            var queryStub = new QueryStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var queryHandler = Substitute.For<IQueryHandler<IQuery<int>, int>>();
            var sut = factory.Create(providerMock);

            providerMock.GetService(typeof(IQueryHandler<QueryStub, int>)).Returns(queryHandler);

            // When
            sut.Dispatch(queryStub);

            // Then
            queryHandler.Received().Handle(queryStub);
        }

        [TestMethod]
        public void Dispatch_KnownQuery_ReturnsValueFromQueryHandler()
        {
            // Given
            var expected = 42;
            var queryStub = new QueryStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var queryHandler = Substitute.For<IQueryHandler<IQuery<int>, int>>();
            var sut = factory.Create(providerMock);

            providerMock.GetService(typeof(IQueryHandler<QueryStub, int>)).Returns(queryHandler);
            queryHandler.Handle(queryStub).Returns(expected);

            // When
            var result = sut.Dispatch(queryStub);

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Dispatch_NoEventObserver_ThrowsRuntimeBinderException()
        {
            // Given
            var providerStub = Substitute.For<IServiceProvider>();
            var sut = (IEventDispatcher)factory.Create(providerStub);
            var someEventStub = Substitute.For<IEvent>();

            // When
            Assert.ThrowsException<RuntimeBinderException>(() =>
            {
                sut.Dispatch(someEventStub);
            });
        }

        [TestMethod]
        public void Dispatch_AnyEvent_CallsGetService()
        {
            // Given
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = (IEventDispatcher)factory.Create(providerMock);

            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<IEventObserver<IEvent>>());

            // When
            sut.Dispatch(Substitute.For<IEvent>());

            // Then
            providerMock.Received().GetService(Arg.Any<Type>());
        }

        [TestMethod]
        public void Dispatch_SpecificEvent_CallsGetServiceWithSpecificObserver()
        {
            // Given
            var eventStub = new EventStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var sut = (IEventDispatcher)factory.Create(providerMock);

            providerMock.GetService(Arg.Any<Type>()).Returns(Substitute.For<IEventObserver<IEvent>>());

            // When
            sut.Dispatch(eventStub);

            // Then
            providerMock.Received().GetService(typeof(IEventObserver<EventStub>));
        }

        [TestMethod]
        public void Dispatch_KnownEvent_CallsInvokeOnObserverWithEvent()
        {
            // Given
            var eventStub = new EventStub();
            var providerMock = Substitute.For<IServiceProvider>();
            var eventObserverMock = Substitute.For<IEventObserver<IEvent>>();
            var sut = (IEventDispatcher)factory.Create(providerMock);

            providerMock.GetService(Arg.Any<Type>()).Returns(eventObserverMock);

            // When
            sut.Dispatch(eventStub);

            // Then
            eventObserverMock.Received().Invoke(eventStub);
        }

        // Dummy classes for test
        public class CommandStub : ICommand
        {
            public Guid ProcessId => throw new NotImplementedException();
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
