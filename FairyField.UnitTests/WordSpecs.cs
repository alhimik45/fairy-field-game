using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace FairyField.UnitTests
{
    public class WordSpecs
    {
            [Subject(typeof(Word))]
            public class When_created
            {
                Establish context = () =>
                {
                    Subject = new Word();
                };

                It should_have_closed_letters = () => Subject.HaveClosedLetters.ShouldBeTrue();

                static Word Subject;
            }
    }
}