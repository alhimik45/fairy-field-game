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

            private It should_fail = () => Exception.ShouldBeOfExactType<ArgumentException>();

            static Exception Exception;
        }
    }
}