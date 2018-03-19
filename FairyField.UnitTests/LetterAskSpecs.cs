using System.IO;
using Machine.Specifications;
using NSubstitute;

namespace FairyField.UnitTests
{
    public class LetterAskSpecs
    {
        [Subject(typeof(LetterAsk))]
        public class When_ask_letter_in_word
        {
            Establish context = () =>
            {
                Input = Substitute.For<TextReader>();
                Output = Substitute.For<TextWriter>();
                Input.ReadLine().Returns("", "a");
                State = new GameState(new Word("a"));
                Subject = new LetterAsk(Input, Output);
            };

            Because of = () => AskResult = Subject.Ask(State);
            
            It should_get_true = () => AskResult.ShouldBeTrue();
            It should_read_input = () => Input.Received(2).ReadLine();
            It should_write_reaction = () => Output.Received().WriteLine(Arg.Any<string>());

            static bool AskResult;
            static LetterAsk Subject;
            static GameState State;
            static TextReader Input;
            static TextWriter Output;
        }
        
        [Subject(typeof(LetterAsk))]
        public class When_ask_letter_not_in_word
        {
            Establish context = () =>
            {
                Input = Substitute.For<TextReader>();
                Output = Substitute.For<TextWriter>();
                Input.ReadLine().Returns("b");
                State = new GameState(new Word("a"));
                Subject = new LetterAsk(Input, Output);
            };

            Because of = () => AskResult = Subject.Ask(State);
            
            It should_get_false = () => AskResult.ShouldBeFalse();
            It should_read_input = () => Input.Received(1).ReadLine();
            It should_write_reaction = () => Output.Received().WriteLine(Arg.Any<string>());

            static bool AskResult;
            static LetterAsk Subject;
            static GameState State;
            static TextReader Input;
            static TextWriter Output;
        }
    }
}