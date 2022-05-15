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
            Assert.ThrowsException<ArgumentNullException>(() => new RegexTokenDefinition(Substitute.For<ITokenFactory>(), null));
        }

        [TestMethod]
        public void Ctor_EmptyRegexPattern_ThrowsArgumentNullException()
        {
            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() => new RegexTokenDefinition(Substitute.For<ITokenFactory>(), ""));
        }

        [TestMethod]
        public void Match_NoMatch_ReturnsNull()
        {
            // Given
            var sut = new RegexTokenDefinition(Substitute.For<ITokenFactory>(), @"\d");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Match_Match_ReturnsIMatch()
        {
            // Given
            var sut = new RegexTokenDefinition(Substitute.For<ITokenFactory>(), @".*");

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
            var sut = new RegexTokenDefinition(Substitute.For<ITokenFactory>(), $"^T");

            // When
            var result = sut.Match("Test");

            // Then
            Assert.AreEqual(expected, result.CharacterLength);
        }

        [TestMethod]
        public void Match_Match_ReturnMatchHasToken()
        {
            // Given
            var expected = Substitute.For<IToken>();
            var factoryStub = Substitute.For<ITokenFactory>();
            var sut = new RegexTokenDefinition(factoryStub, $"^T");
            factoryStub.Create(Arg.Any<string>()).Returns(expected);

            // When
            var result = sut.Match("Test");

            // Then
            Assert.AreEqual(expected, result.Token);
        }
    }
}
