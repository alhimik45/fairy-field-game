using System.IO;
using FairyField.DrumActions;
using Machine.Specifications;
using NSubstitute;

namespace FairyField.UnitTests
{
    public class DoubleActionSpecs
    {
        [Subject(typeof(DoubleAction))]
        public class When_act
        {
            Establish context = () =>
            {
                State = new GameState(new Word("a")) {Scores = 42};
                Subject = new DoubleAction(Substitute.For<TextWriter>());
            };

            Because of = () => Subject.Act(State);

            It should_double_score = () => State.Scores.ShouldEqual(84);

            static DoubleAction Subject;
            static GameState State;
        }
    }
}