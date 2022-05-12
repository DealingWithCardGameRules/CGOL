using dk.itu.game.msc.cgdl.Distribution;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgdl.CommandCentral.Test
{
    [TestClass]
    public class TestEventDispatcher
    {
        [TestMethod]
        public void Dispatch_AnyEvent_CallsSupports()
        {
            // Given
            var providerMock = Substitute.For<IInterpreter>();
            var sut = new EventDispatcher(providerMock);

            // When
            sut.Dispatch(Substitute.For<IEvent>());

            // Then
            providerMock.Received().Supports(Arg.Any<IEvent>());
        }

        [TestMethod]
        public void Dispatch_NotSupported_DoesNotCallGetService()
        {
            // Given
            var providerMock = Substitute.For<IInterpreter>();
            var sut = new EventDispatcher(providerMock);
            providerMock.Supports(Arg.Any<IEvent>()).Returns(false);

            // When
            sut.Dispatch(Substitute.For<IEvent>());

            // Then
            providerMock.DidNotReceive().GetService(Arg.Any<Type>());
        }

        [TestMethod]
        public void Dispatch_SpecificEvent_CallsGetServiceWithSpecificObserver()
        {
            // Given
            var eventStub = new EventStub();
            var providerMock = Substitute.For<IInterpreter>();
            var sut = new EventDispatcher(providerMock);
            providerMock.Supports(Arg.Any<IEvent>()).Returns(true);
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
            var providerMock = Substitute.For<IInterpreter>();
            var eventObserverMock = Substitute.For<IEventObserver<IEvent>>();
            var sut = new EventDispatcher(providerMock);
            providerMock.Supports(Arg.Any<IEvent>()).Returns(true);
            providerMock.GetService(Arg.Any<Type>()).Returns(eventObserverMock);

            // When
            sut.Dispatch(eventStub);

            // Then
            eventObserverMock.Received().Invoke(eventStub);
        }

        public class EventStub : IEvent
        {
            public DateTime EventTime => throw new NotImplementedException();
            public int Version => throw new NotImplementedException();
            public Guid ProcessId => throw new NotImplementedException();
        }
    }
}
