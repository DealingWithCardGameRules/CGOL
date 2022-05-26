using dk.itu.game.msc.cgol.Parser.Lexers;
using dk.itu.game.msc.cgol.Parser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgol.LanguageParser.Test
{
    [TestClass]
    public class TestRegexTokenDefinition
    {
        [TestMethod]
        public void Ctor_NullToken_ThrowsArgumentNullException()
        {
            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() => new RegexTokenDefinition(null, "test"));
        }

        [TestMethod]
        public void Ctor_NullRegexPattern_ThrowsArgumentNullException()
        {
            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() => new RegexTokenDefinition((_)=>Substitute.For<Token>(), null));
        }

        [TestMethod]
        public void Ctor_EmptyRegexPattern_ThrowsArgumentNullException()
        {
            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() => new RegexTokenDefinition((_)=>Substitute.For<Token>(), ""));
        }

        [TestMethod]
        public void Match_NoMatch_ReturnsNull()
        {
            // Given
            var sut = new RegexTokenDefinition((_)=>Substitute.For<Token>(), @"\d");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Match_Match_ReturnsIMatch()
        {
            // Given
            var sut = new RegexTokenDefinition((val) => Substitute.For<Token>(val), @".*");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.IsInstanceOfType(result, typeof(ITokenMatch));
        }

        [TestMethod]
        public void Match_Match_ReturnMatchHasCharacterLength()
        {
            // Given
            var expected = 1;
            var sut = new RegexTokenDefinition((val) => Substitute.For<Token>(val), $"^T");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.AreEqual(expected, result.Length);
        }

        [TestMethod]
        public void Match_Match_ReturnMatchHasToken()
        {
            // Given
            var expected = Substitute.For<Token>("");
            var sut = new RegexTokenDefinition((_)=> expected, $"^T");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.AreEqual(expected, result.Token);
        }
    }
}
