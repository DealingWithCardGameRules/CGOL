using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace dk.itu.game.msc.cgdl.LanguageParser.Test
{
    [TestClass]
    public class TestTokenDefinitionComposite
    {
        [TestMethod]
        public void Match_NoTokenDefinitions_ReturnsNull()
        {
            // Given
            var sut = new TokenDefinitionComposite();

            // When
            var result = sut.Match(null);

            // Then
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Match_AnyTokenDefinition_CallsMathOnTokenDefinition()
        {
            // Given
            var tokenDefinitionMock = Substitute.For<ITokenDefinition>();
            var sut = new TokenDefinitionComposite(tokenDefinitionMock);

            // When
            sut.Match(null);

            // Then
            tokenDefinitionMock.Received().Match(null);
        }

        [TestMethod]
        public void Match_TokenDefinitionReturnsMatch_ReturnsMatch()
        {
            // Given
            var tokenDefinitionStub = Substitute.For<ITokenDefinition>();
            var sut = new TokenDefinitionComposite(tokenDefinitionStub);
            var expected = Substitute.For<ITokenMatch>();
            tokenDefinitionStub.Match(Arg.Any<string>()).Returns(expected);

            // When
            var result = sut.Match(null);

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Match_FirstDefinitionReturnsNull_CallsMatchOnSuccessor()
        {
            // Given
            var firstDefinitionStub = Substitute.For<ITokenDefinition>();
            var successorMock = Substitute.For<ITokenDefinition>();
            var sut = new TokenDefinitionComposite(firstDefinitionStub, successorMock);
            firstDefinitionStub.Match(Arg.Any<string>()).ReturnsNull();

            // When
            sut.Match(null);

            // Then
            successorMock.Received().Match(null);
        }

        [TestMethod]
        public void Match_FirstDefinitionReturnsMatch_SuccessorIsNotCalled()
        {
            // Given
            var firstDefinitionStub = Substitute.For<ITokenDefinition>();
            var successorMock = Substitute.For<ITokenDefinition>();
            var sut = new TokenDefinitionComposite(firstDefinitionStub, successorMock);
            firstDefinitionStub.Match(Arg.Any<string>()).Returns(Substitute.For<ITokenMatch>());

            // When
            sut.Match(null);

            // Then
            successorMock.DidNotReceive().Match(Arg.Any<string>());
        }

        [TestMethod]
        public void Match_AllDefinitionsReturnsNull_ReturnsNull()
        {
            // Given
            var firstDefinitionStub = Substitute.For<ITokenDefinition>();
            var successorStub = Substitute.For<ITokenDefinition>();
            var sut = new TokenDefinitionComposite(firstDefinitionStub, successorStub);
            firstDefinitionStub.Match(Arg.Any<string>()).ReturnsNull();
            successorStub.Match(Arg.Any<string>()).ReturnsNull();

            // When
            var result = sut.Match(null);

            // Then
            Assert.IsNull(result); 
        }
    }
}
