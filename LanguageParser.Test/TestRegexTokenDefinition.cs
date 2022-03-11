using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Test
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
            Assert.ThrowsException<ArgumentNullException>(() => new RegexTokenDefinition(Substitute.For<IToken>(), null));
        }

        [TestMethod]
        public void Ctor_EmptyRegexPattern_ThrowsArgumentNullException()
        {
            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() => new RegexTokenDefinition(Substitute.For<IToken>(), ""));
        }

        [TestMethod]
        public void Match_NoMatch_ReturnsNull()
        {
            // Given
            var sut = new RegexTokenDefinition(Substitute.For<IToken>(), @"\d");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Match_Match_ReturnsIMatch()
        {
            // Given
            var sut = new RegexTokenDefinition(Substitute.For<IToken>(), @".*");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.IsInstanceOfType(result, typeof(ITokenMatch));
        }

        [TestMethod]
        public void Match_Match_ReturnMatchHasValue()
        {
            // Given
            var expected = "T";
            var sut = new RegexTokenDefinition(Substitute.For<IToken>(), $"^{expected}");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod]
        public void Match_Match_ReturnMatchHasRemainingText()
        {
            // Given
            var expected = "est";
            var sut = new RegexTokenDefinition(Substitute.For<IToken>(), $"^T");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.AreEqual(expected, result.RemainingText);
        }

        [TestMethod]
        public void Match_Match_ReturnMatchHasToken()
        {
            // Given
            var expected = Substitute.For<IToken>();
            var sut = new RegexTokenDefinition(expected, $"^T");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.AreEqual(expected, result.Token);
        }
    }
}
