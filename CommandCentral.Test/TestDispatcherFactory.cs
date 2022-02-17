using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace dk.itu.game.msc.cgdl.CommandCentral.Test
{
    [TestClass]
    public class TestDispatcherFactory
    {

        [TestMethod]
        public void Create_Null_ThrowsArgumentNullException()
        {
            // Given
            var sut = new DispatchFactory();

            // When, then
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                sut.Create(null);
            });
        }

    }
}
