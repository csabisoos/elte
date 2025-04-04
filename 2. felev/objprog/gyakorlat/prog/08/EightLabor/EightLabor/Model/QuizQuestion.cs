namespace EightLabor
{
    public class QuizQuestion : IGuessable
    {
        // Fields
        private readonly string question;
        private readonly string[] answers;
        private readonly int correct;
        
        // Properties
        public string Question => question;
        public string[] Answers => answers;
        
        // Constructors
        public QuizQuestion(string question, string[] answers, int correct)
        {
            this.question = question;
            this.answers = answers;
            this.correct = correct;
        }
        
        // Methods
        public bool Guess(int guess)
        {
            return correct == guess;
        }
    }
}

