namespace FairyField
{
    public class GameState
    {
        public Word CurrentWord { get; }
        public int Scores { get; set; }

        public GameState(Word currentWord)
        {
            CurrentWord = currentWord;
        }
    }
}