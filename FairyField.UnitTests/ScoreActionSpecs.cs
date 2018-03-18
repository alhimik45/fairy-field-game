using System.IO;
using FairyField.DrumActions;
using Machine.Specifications;
using NSubstitute;

namespace FairyField.UnitTests
{
    public class ScoreActionSpecs
    {
        [Subject(typeof(ScoreAction))]
        public class When_letter_guessed_right
        {
            Establish context = () =>
            {
                State = new GameState(new Word("a"));
                LetterAsk = Substitute.For<ILetterAsk>();
                LetterAsk.Ask(State).Returns(true);
                Output = Substitute.For<TextWriter>();
                Subject = new ScoreAction(10, LetterAsk, Output);
            };

            Because of = () => Subject.Act(State);

            It should_output_something = () => Output.Received().WriteLine(Arg.Any<string>());
            It should_ask_for_letter = () => LetterAsk.Received().Ask(State);
            It should_increase_score = () => State.Scores.ShouldEqual(10);

            static ScoreAction Subject;
            static GameState State;
            static TextWriter Output;
            static ILetterAsk LetterAsk;
        }
        
        [Subject(typeof(ScoreAction))]
        public class When_letter_guessed_wrong
        {
            Establish context = () =>
            {
                State = new GameState(new Word("a"));
                LetterAsk = Substitute.For<ILetterAsk>();
                LetterAsk.Ask(State).Returns(false);
                Output = Substitute.For<TextWriter>();
                Subject = new ScoreAction(10, LetterAsk, Output);
            };

            Because of = () => Subject.Act(State);

            It should_ask_for_letter = () => LetterAsk.Received().Ask(State);
            It should_not_change_score = () => State.Scores.ShouldEqual(0);

            static ScoreAction Subject;
            static GameState State;
            static TextWriter Output;
            static ILetterAsk LetterAsk;
        }
    }
}