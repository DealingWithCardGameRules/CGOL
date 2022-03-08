using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser.Test
{
    [TestClass]
    public class TestLexer
    {
        [TestMethod]
        public void Tokenize_AnyTokenDifinition_Calls()
        {
            // Given
            var sut = new Lexer();
            var definitionMock = Substitute.For<ITokenDefinition>();
            sut.Add(definitionMock);
            var expected = "Test";

            // When
            sut.Tokenize(aList(expected)).ToArray();

            // Then
            definitionMock.Received().Match(expected);
        }
        
        private T[] aList<T>(params T[] list) => list;
    }
}
