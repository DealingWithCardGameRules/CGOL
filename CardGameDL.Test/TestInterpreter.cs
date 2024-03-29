﻿using dk.itu.game.msc.cgol.Distribution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Test
{
    [TestClass]
    public class TestInterpreter
    {
        [TestMethod]
        public void GetService_UnknownType_ThrowsUnknownConceptException()
        {
            // Given
            var sut = new Interpreter();

            // When, Then
            Assert.ThrowsException<UnknownConceptException>(() =>
            {
                sut.GetService(this.GetType());
            });
        }

        [TestMethod]
        public void GetService_KnownCommandHandler_ReturnsCommandHandler()
        {
            // Given
            var sut = new Interpreter();
            var expected = Substitute.For<ICommandHandler<ICommand>>();
            sut.AddConcept(expected);

            // When
            var result = sut.GetService(typeof(ICommandHandler<ICommand>));

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetService_KnownQueryHandler_ReturnsQueryHandler()
        {
            // Given
            var sut = new Interpreter();
            var expected = Substitute.For<IQueryHandler<IQuery<int>, int>>();
            sut.AddConcept(expected);

            // When
            var result = sut.GetService(typeof(IQueryHandler<IQuery<int>, int>));

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetService_ConcreteCommandHandler_ReturnsCommandHandler()
        {
            // Given
            var sut = new Interpreter();
            var expected = new CommandHandlerStub();
            sut.AddConcept(expected);

            // When
            var result = sut.GetService(typeof(ICommandHandler<CommandStub>));

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetService_ConcreteQueryHandler_ReturnsQueryHandler()
        {
            // Given
            var sut = new Interpreter();
            var expected = new QueryHandlerStub();
            sut.AddConcept(expected);

            // When
            var result = sut.GetService(typeof(IQueryHandler<QueryStub, bool>));

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetService_RemovedCommandHandler_ThrowsUnknownConceptException()
        {
            // Given
            var sut = new Interpreter();
            var commandHandlerStud = new CommandHandlerStub();
            sut.AddConcept(commandHandlerStud);
            sut.RemoveConcept(commandHandlerStud);

            // When, Then
            Assert.ThrowsException<UnknownConceptException>(() =>
            {
                sut.GetService(typeof(ICommandHandler<CommandStub>));
            });
        }

        [TestMethod]
        public void GetService_RemovedQueryHandler_ThrowsUnknownConceptException()
        {
            // Given
            var sut = new Interpreter();
            var queryHandlerStud = new QueryHandlerStub();
            sut.AddConcept(queryHandlerStud);
            sut.RemoveConcept(queryHandlerStud);

            // When, Then
            Assert.ThrowsException<UnknownConceptException>(() =>
            {
                sut.GetService(typeof(IQueryHandler<QueryStub, bool>));
            });
        }

        [TestMethod]
        public void GetService_RemovedEventObserver_ThrowsUnknownConceptException()
        {
            // Given
            var sut = new Interpreter();
            var eventObserverStud = new EventObserverStub();
            sut.AddConcept(eventObserverStud);
            sut.RemoveConcept(eventObserverStud);

            // When, Then
            Assert.ThrowsException<UnknownConceptException>(() =>
            {
                sut.GetService(typeof(IEventObserver<EventStub>));
            });
        }

        [TestMethod]
        public void Supports_UnknownEvent_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();

            // When
            var result = sut.Supports<EventStub>();

            // Then
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void Supports_UnknownCommand_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();

            // When
            var result = sut.Supports<CommandStub>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_UnknownQuery_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();

            // When
            var result = sut.Supports<QueryStub>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_OtherUnknownQuery_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(Substitute.For<IQueryHandler<IQuery<bool>, bool>>());

            // When
            var result = sut.Supports<QueryStub>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_AskForQueryInterface_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new QueryHandlerStub());

            // When
            var result = sut.Supports<IQuery<bool>>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_AskForCommandInterface_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new CommandHandlerStub());

            // When
            var result = sut.Supports<ICommand>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_AskForEventInterface_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new EventObserverStub());

            // When
            var result = sut.Supports<IEvent>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_KnownEvent_ReturnsTrue()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(Substitute.For<IEventObserver<IEvent>>());

            // When
            var result = sut.Supports<IEvent>();

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Supports_KnownQuery_ReturnsTrue()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(Substitute.For<IQueryHandler<IQuery<int>, int>>());

            // When
            var result = sut.Supports<IQuery<int>>();

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Supports_KnownCommand_ReturnsTrue()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(Substitute.For<ICommandHandler<ICommand>>());

            // When
            var result = sut.Supports<ICommand>();

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Supports_ConcreteCommand_ReturnsTrue()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new CommandHandlerStub());

            // When
            var result = sut.Supports<CommandStub>();

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Supports_ConcreteQuery_ReturnsTrue()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new QueryHandlerStub());

            // When
            var result = sut.Supports<QueryStub>();

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Supports_ConcreteEvent_ReturnsTrue()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new EventObserverStub());

            // When
            var result = sut.Supports<EventStub>();

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Supports_RemovedEvent_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();
            var observerStub = new EventObserverStub();
            sut.AddConcept(observerStub);
            sut.RemoveConcept(observerStub);

            // When
            var result = sut.Supports<EventStub>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_RemovedCommand_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new CommandHandlerStub());
            sut.RemoveConcept(new CommandHandlerStub());

            // When
            var result = sut.Supports<CommandStub>();

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Supports_RemovedQuery_ReturnsFalse()
        {
            // Given
            var sut = new Interpreter();
            sut.AddConcept(new QueryHandlerStub());
            sut.RemoveConcept(new QueryHandlerStub());

            // When
            var result = sut.Supports<QueryStub>();

            // Then
            Assert.IsFalse(result);
        }

        // Stub classes for concrete tests

        public class CommandStub : ICommand
        {
            public System.Guid ProcessId => throw new System.NotImplementedException();

            public System.Guid Instance => throw new System.NotImplementedException();
        }

        class CommandHandlerStub : ICommandHandler<CommandStub>
        {
            public async Task Handle(CommandStub command, IEventDispatcher eventDispatcher)
            {
                throw new System.NotImplementedException();
            }
        }

        public class QueryStub : IQuery<bool> { }

        class QueryHandlerStub : IQueryHandler<QueryStub, bool>
        {
            public async Task<bool> Handle(QueryStub query)
            {
                throw new System.NotImplementedException();
            }
        }

        public class EventStub : IEvent
        {
            public System.DateTime EventTime => throw new System.NotImplementedException();
            public int Version => throw new System.NotImplementedException();
            public System.Guid ProcessId => throw new System.NotImplementedException();
        }

        class EventObserverStub : IEventObserver<EventStub>
        {
            public async Task Invoke(EventStub @event)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
