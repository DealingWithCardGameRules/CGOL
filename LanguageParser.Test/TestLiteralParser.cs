using dk.itu.game.msc.cgdl.LanguageParser.Parsers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Test
{
    [TestClass]
    public class TestLiteralParser
    {
        [TestMethod]
        public void Parse_ApplyTokenNeverCallsCallback_ThrowsGDLParserException()
        {
            // Given
            var sut = new LiteralParser();
            
            // When, then
            Assert.ThrowsException<GDLParserException>(() => {
                sut.Parse(Substitute.For<IParserStack>());
                });
        }

        [TestMethod]
        public void Parse_AnyStack_CallsApplyTokenWithStringLiteralAction()
        {
            // Given
            var sut = new LiteralParser();
            var stackMock = Substitute.For<IParserStack>();

            // When
            try { // Ignore exceptions
                sut.Parse(stackMock);
            } catch {}

            // Then
            stackMock.Received().ApplyToken(Arg.Any<Action<StringLiteral>>());
        }

        [TestMethod]
        public void Parse_AnyStack_CallsApplyTokenWithNumberLiteralAction()
        {
            // Given
            var sut = new LiteralParser();
            var stackMock = Substitute.For<IParserStack>();

            // When
            try
            { // Ignore exceptions
                sut.Parse(stackMock);
            }
            catch { }

            // Then
            stackMock.Received().ApplyToken(Arg.Any<Action<NumberLiteral>>());
        }

        [TestMethod]
        public void Parse_StringLiteralIsApplied_ResultIsString()
        {
            // Given
            var sut = new LiteralParser();
            var stackStub = Substitute.For<IParserStack>();
            var literal = new StringLiteral();
            literal.Parse("\"\"");
            stackStub.ApplyToken(Arg.Do<Action<StringLiteral>>(a => a(literal)));

            // When
            sut.Parse(stackStub);
            var result = sut.Result;

            // Then
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void Parse_NumberLiteralIsApplied_ResultIsInteger()
        {
            // Given
            var sut = new LiteralParser();
            var stackStub = Substitute.For<IParserStack>();
            var literal = new NumberLiteral();
            literal.Parse("0");
            stackStub.ApplyToken(Arg.Do<Action<NumberLiteral>>(a => a(literal)));

            // When
            sut.Parse(stackStub);
            var result = sut.Result;

            // Then
            Assert.IsInstanceOfType(result, typeof(int));
        }
    }
}
