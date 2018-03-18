using Machine.Specifications;

namespace FairyField.UnitTests
{
    public class WeightedChooserSpecs
    {
        [Subject(typeof(WeightedChooser<>))]
        public class When_getting_by_offset
        {
            Establish context = () =>
            {
                Subject = new WeightedChooser<int>(new[]
                {
                    (1, 1),
                    (2, 2),
                    (3, 4),
                    (5, 6)
                });
            };

            class get_1
            {
                Because of = () => Result = Subject.GetByOffset(1);
                
                It should_return_1 = () => Result.ShouldEqual(1);                
            }
            
            class get_24
            {
                Because of = () => Result = Subject.GetByOffset(24);
                
                It should_return_5 = () => Result.ShouldEqual(5);                
            }

            static WeightedChooser<int> Subject;
            static int Result;
        }
    }
}