using System;
using Machine.Specifications;

namespace FairyField.UnitTests
{
    public class WordSpecs
    {
        [Subject(typeof(Word))]
        public class When_created_with_null
        {
            Because of = () => Exception = Catch.Exception(() => new Word(null));

            It should_fail = () => Exception.ShouldBeOfExactType<ArgumentException>();

            static Exception Exception;
        }

        [Subject(typeof(Word))]
        public class When_created_with_empty_string
        {
            Because of = () => Exception = Catch.Exception(() => new Word(""));

            It should_fail = () => Exception.ShouldBeOfExactType<ArgumentException>();

            static Exception Exception;
        }

        [Subject(typeof(Word))]
        public class When_created_with_hello_string
        {
            Establish context = () => { Subject = new Word("hello"); };

            It should_have_closed_letters = () => Subject.HaveClosedLetters.ShouldBeTrue();

            static Word Subject;
        }
    }
}