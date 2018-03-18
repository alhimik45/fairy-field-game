using Machine.Specifications;

namespace FairyField.UnitTests
{
    public class GameStateSpecs
    {
        [Subject(typeof(Word))]
        public class When_created
        {
            Establish context = () => { Subject = new GameState(new Word("a")); };

            It should_have_zero_score = () => Subject.Scores.ShouldEqual(0);

            static GameState Subject;
        }
    }
}