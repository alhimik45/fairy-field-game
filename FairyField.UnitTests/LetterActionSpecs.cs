using System.IO;
using FairyField.DrumActions;
using Machine.Specifications;
using NSubstitute;

namespace FairyField.UnitTests
{
    public class LetterActionSpecs
    {
        [Subject(typeof(LetterAction))]
        public class When_act
        {
            Establish context = () =>
            {
                Input = Substitute.For<TextReader>();
                Input.ReadLine().Returns("0", "-13", "445", "sdsd","1");
                State = new GameState(new Word("a"));
                Subject = new LetterAction(Input, Substitute.For<TextWriter>());
            };

            Because of = () => Subject.Act(State);

            It should_open_letter = () => State.CurrentWord.View.ShouldEqual("a");
            It should_read_5_times = () => Input.Received(5).ReadLine();

            static LetterAction Subject;
            static GameState State;
            static TextReader Input;
        }
    }
}