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
        public class When_created_with_string_with_multiple_words
        {
            Because of = () => Exception = Catch.Exception(() => new Word("multiple words"));

            It should_fail = () => Exception.ShouldBeOfExactType<ArgumentException>();

            static Exception Exception;
        }

        [Subject(typeof(Word))]
        public class When_created_with_hello_string
        {
            Establish context = () => { Subject = new Word("hello"); };

            Because of = () => Subject.Open('l');
            
            It should_have_closed_letters = () => Subject.HaveClosedLetters.ShouldBeTrue();
            It should_have_view = () => Subject.View.ShouldEqual("**ll*");

            static Word Subject;
        }
        
        [Subject(typeof(Word))]
        public class When_created_with_a_string
        {
            Establish context = () => { Subject = new Word("a"); };

            Because of = () => Subject.Open('a');
            
            It should_not_have_closed_letters = () => Subject.HaveClosedLetters.ShouldBeFalse();
            It should_have_view = () => Subject.View.ShouldEqual("a");

            static Word Subject;
        }
        
        [Subject(typeof(Word))]
        public class When_created_with_ab_string
        {
            Establish context = () => { Subject = new Word("ab"); };

            class open_a
            {
                Because of = () => OpenResult = Subject.Open('a');
                It should_have_closed_letters = () => Subject.HaveClosedLetters.ShouldBeTrue();
                It should_have_view = () => Subject.View.ShouldEqual("a*");
                It should_return_true_on_open = () => OpenResult.ShouldBeTrue();

                static bool OpenResult;
            }
            
            class open_ab
            {
                Because of = () =>
                {
                    Subject.Open('a');
                    Subject.Open('b');
                };
                It should_not_have_closed_letters = () => Subject.HaveClosedLetters.ShouldBeFalse();
                It should_have_view = () => Subject.View.ShouldEqual("ab");
            }
            
            static Word Subject;
        }
    }
}