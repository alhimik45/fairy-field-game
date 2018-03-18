using System;

namespace FairyField
{
    public class Word
    {
        public bool HaveClosedLetters => true;

        public Word(string word)
        {
            throw new ArgumentException();
        }
    }
}