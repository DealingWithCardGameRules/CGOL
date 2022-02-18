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
        public void Dispatch_NoEventObserver_ThrowsRuntimeBinderException()
        {
            // Given
            var providerStub = Substitute.For<IServiceProvider>();
            var sut = new EventDispatcher(providerStub);
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
            var sut = new EventDispatcher(providerMock);

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
            var sut = new EventDispatcher(providerMock);

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
            var sut = new EventDispatcher(providerMock);

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
