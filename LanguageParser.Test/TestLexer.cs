using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser.Test
{
    [TestClass]
    public class TestLexer
    {
        [TestMethod]
        public void Tokenize_AnyTokenDifinition_CallsMatchPerLine()
        {
            // Given
            var definitionMock = Substitute.For<ITokenDefinition>();
            var sut = new Lexer(definitionMock);
            var expected = "Test";

            // When
            sut.Tokenize(aList(expected)).ToArray(); // ToArray forces the IEnumerable to run

            // Then
            definitionMock.Received().Match(expected);
        }

        [TestMethod]
        public void Tokenize_NoMatch_ReturnsOnlySequenceTerminator()
        {
            // Given
            var definitionStub = Substitute.For<ITokenDefinition>();
            var sut = new Lexer(definitionStub);
            definitionStub.Match(Arg.Any<string>()).ReturnsNull();

            // When
            var result = sut.Tokenize(aList("Test"));

            // Then
            Assert.IsInstanceOfType(result.Single(), typeof(SequenceTerminator));
        }

        [TestMethod]
        public void Tokenize_Match_ReturnsTwoTokens()
        {
            // Given
            var definitionStub = Substitute.For<ITokenDefinition>();
            var sut = new Lexer(definitionStub);
            var expected = 2;
            definitionStub.Match(Arg.Any<string>()).Returns(Substitute.For<ITokenMatch>());

            // When
            var result = sut.Tokenize(aList("Test"));

            // Then
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public void Tokenize_Match_CallsTokenOnMatch()
        {

            // Given
            var definitionStub = Substitute.For<ITokenDefinition>();
            var sut = new Lexer(definitionStub);
            var matchMock = Substitute.For<ITokenMatch>();
            definitionStub.Match(Arg.Any<string>()).Returns(matchMock);

            // When
            sut.Tokenize(aList("Test")).ToArray(); // ToArray forces the IEnumerable to run

            // Then
            _ = matchMock.Received().Token;

        }

        [TestMethod]
        public void Tokenize_Match_ReturnsTokenMatch()
        {
            
            // Given
            var definitionStub = Substitute.For<ITokenDefinition>();
            var sut = new Lexer(definitionStub);
            var expected = Substitute.For<IToken>();
            var matchStub = Substitute.For<ITokenMatch>();
            
            definitionStub.Match(Arg.Any<string>()).Returns(matchStub);
            matchStub.Token.Returns(expected);

            // When
            var result = sut.Tokenize(aList("Test"));

            // Then
            result.Contains(expected);
            
        }

        private T[] aList<T>(params T[] list) => list;
    }
}
