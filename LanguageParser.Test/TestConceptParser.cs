using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.LanguageParser.Parsers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Test
{
    [TestClass]
    public class TestConceptParser
    {
        [TestMethod]
        public void Ctor_InterpolatorIsNull_ThrowsArgumentNullException()
        {
            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new ConceptParser(null, Substitute.For<IParser<object>>());
            });
        }

        [TestMethod]
        public void Ctor_LiteralParserIsNull_ThrowsArgumentNullException()
        {
            // When, Then
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new ConceptParser(Substitute.For<IInterpolator>(), null);
            });
        }

        [TestMethod]
        public void Parse_AnyParserStack_CallsReadTokenWithConcept()
        {
            // Given
            var sut = new ConceptParser(Substitute.For<IInterpolator>(), Substitute.For<IParser<object>>());
            var stackMock = Substitute.For<IParserQueue>();

            // When
            try {
                sut.Parse(stackMock);
            } catch { }

            // Then
            stackMock.Received().ReadToken<Concept>();
        }

        [TestMethod]
        public void Parse_KnownConcept_CallsResolveCommandWithConceptName()
        {
            // Given
            var interpolatorMock = Substitute.For<IInterpolator>();
            var sut = new ConceptParser(interpolatorMock, Substitute.For<IParser<object>>());
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());

            // When
            try {
                sut.Parse(stackStub);
            } catch { }

            // Then
            interpolatorMock.Received().ResolveCommand(Arg.Any<string>());
        }

        [TestMethod]
        public void Parse_UnknownConcept_ThrowsGDLParserException()
        {
            // Given
            var sut = new ConceptParser(Substitute.For<IInterpolator>(), Substitute.For<IParser<object>>());
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());

            // When, Then
            Assert.ThrowsException<GDLParserException>(() => sut.Parse(stackStub));
        }

        [TestMethod]
        public void Parse_KnownConcept_CallsDiscardToken()
        {
            // Given
            var interpolatorStub = Substitute.For<IInterpolator>();
            var sut = new ConceptParser(interpolatorStub, Substitute.For<IParser<object>>());
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());
            interpolatorStub.ResolveCommand(Arg.Any<string>()).Returns(typeof(SimpleCommand));

            // When
            sut.Parse(stackStub);

            // Then
            stackStub.Received().DiscardToken();
        }

        [TestMethod]
        public void Parse_NoneCommandType_ThrowsException()
        {
            // Given
            var interpolatorStub = Substitute.For<IInterpolator>();
            var sut = new ConceptParser(interpolatorStub, Substitute.For<IParser<object>>());
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());
            interpolatorStub.ResolveCommand(Arg.Any<string>()).Returns(typeof(string));

            // When, Then
            Assert.ThrowsException<Exception>(() => sut.Parse(stackStub));
        }

        [TestMethod]
        public void Parse_CommandWithConstructorParameters_CallsParseOnLiteralParserForEveryArgument()
        {
            // Given
            var interpolatorStub = Substitute.For<IInterpolator>();
            var parseMock = Substitute.For<IParser<object>>();
            var sut = new ConceptParser(interpolatorStub, parseMock);
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());
            interpolatorStub.ResolveCommand(Arg.Any<string>()).Returns(typeof(ComplexCommand));

            // When
            try {
                sut.Parse(stackStub);
            } catch { }
            
            // Then
            parseMock.Received(2).Parse(stackStub);
        }

        [TestMethod]
        public void Parse_LiteralMismatchWithCtorParameters_ThrowsGDLParserException()
        {
            // Given
            var interpolatorStub = Substitute.For<IInterpolator>();
            var parseMock = Substitute.For<IParser<object>>();
            var sut = new ConceptParser(interpolatorStub, parseMock);
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());
            interpolatorStub.ResolveCommand(Arg.Any<string>()).Returns(typeof(ComplexCommand));

            // When, Then
            Assert.ThrowsException<GDLParserException>(() => sut.Parse(stackStub));
        }

        [TestMethod]
        public void Parse_InterpolatorReturnsSimpleCommandType_ResultIsSimpleCommandInstance()
        {
            // Given
            var interpolatorStub = Substitute.For<IInterpolator>();
            var parseMock = Substitute.For<IParser<object>>();
            var sut = new ConceptParser(interpolatorStub, parseMock);
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());
            interpolatorStub.ResolveCommand(Arg.Any<string>()).Returns(typeof(SimpleCommand));

            // When
            sut.Parse(stackStub);

            // Then
            Assert.IsInstanceOfType(sut.Result, typeof(SimpleCommand));   
        }


        [TestMethod]
        public void Parse_MatchArgumentsForComplexCommand_ResultIsComplexCommandInstance()
        {
            // Given
            var interpolatorStub = Substitute.For<IInterpolator>();
            var parseStub = Substitute.For<IParser<object>>();
            var sut = new ConceptParser(interpolatorStub, parseStub);
            var stackStub = Substitute.For<IParserQueue>();
            stackStub.ReadToken<Concept>().Returns(new Concept());
            interpolatorStub.ResolveCommand(Arg.Any<string>()).Returns(typeof(ComplexCommand));
            _ = parseStub.Result.Returns("test", 0);

            // When
            sut.Parse(stackStub);

            // Then
            Assert.IsInstanceOfType(sut.Result, typeof(ComplexCommand));
        }
    }

    public class SimpleCommand : ICommand
    {
        public Guid ProcessId => throw new NotImplementedException();
    }

    public class ComplexCommand : ICommand
    {
        public Guid ProcessId => throw new NotImplementedException();

        public ComplexCommand(string arg1, int arg2)
        {
            Console.WriteLine($"First argument: {arg1}");
            Console.WriteLine($"Second argument: {arg2}");
        }
    }
}
