using System;
using System.IO;
using FairyField.DrumActions;
using Machine.Specifications;
using NSubstitute;

namespace FairyField.UnitTests
{
    public class BakruptActionSpecs
    {
        [Subject(typeof(BankruptAction))]
        public class When_act
        {
            Establish context = () =>
            {
                State = new GameState(new Word("a")) {Scores = 42};
                Subject = new BankruptAction(Substitute.For<TextWriter>());
            };

            Because of = () => Subject.Act(State);

            It should_set_state_scores_to_zero = () => State.Scores.ShouldEqual(0);

            static BankruptAction Subject;
            static GameState State;
        }
    }
}