using EightLabor.Persistence;

namespace EightLabor
{
    public class QuizModel : IGuessable, IPageable
    {
        // Constants
        public const int AnswerCount = 4;
        
        // Fields
        private QuizQuestion[] questions;
        private QuizFileManager manager;
        private int[] points;
        private int current;
        
        // Properties
        public QuizQuestion CurrentQuestion => questions[current];
        public int QuestionCount => questions.Length;
        public int Points => points.Sum();
        
        // Constructors
        public QuizModel(string path)
        {
            manager = new(path);
            questions = manager.Load().Select(q => q.Create()).ToArray();
            points = new int[questions.Length];
        }
        
        // Methods
        public bool Guess(int guess)
        {
            bool correct = questions[current].Guess(guess);
            /*if (correct) points[current] = 1;
            else points[current] = 0;*/
            points[current] = correct ? 1 : 0;
            return correct;
        }

        public void Next()
        {
            if (current < points.Length-1) ++current;
        }

        public void Previous()
        {
            if (current > 0) --current;
        }
    }
}

