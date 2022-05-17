using dk.itu.game.msc.cgdl.Parser.Lexers;
using dk.itu.game.msc.cgdl.Parser.Tokens;
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
            sut.Tokenize(expected).ToArray(); // ToArray forces the IEnumerable to run

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
            var result = sut.Tokenize("Test");

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
            var matchMock = Substitute.For<ITokenMatch>();
            var _ = matchMock.Length.Returns(4);
            definitionStub.Match(Arg.Any<string>()).Returns(matchMock);

            // When
            var result = sut.Tokenize("Test");

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
            sut.Tokenize("Test").ToArray(); // ToArray forces the IEnumerable to run

            // Then
            _ = matchMock.Received().Token;
        }

        [TestMethod]
        public void Tokenize_Match_ReturnsTokenMatch()
        {
            
            // Given
            var definitionStub = Substitute.For<ITokenDefinition>();
            var sut = new Lexer(definitionStub);
            var expected = Substitute.For<Token>("");
            var matchStub = Substitute.For<ITokenMatch>();
            
            definitionStub.Match(Arg.Any<string>()).Returns(matchStub);
            matchStub.Token.Returns(expected);

            // When
            var result = sut.Tokenize("Test");

            // Then
            result.Contains(expected);
        }
    }
}
