using System;

namespace FairyField
{
    public class Word
    {
        public bool HaveClosedLetters { get; private set; } = true;

        public Word(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("null or empty", nameof(word));
            }

            if (word.Contains(" "))
            {
                throw new ArgumentException("contains whitespaces", nameof(word));
            }
        }

        public void Open(char letter)
        {
            HaveClosedLetters = false;
        }
    }
}