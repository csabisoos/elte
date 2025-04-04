namespace EightLabor.Persistence
{
    public class QuizQuestionDraft
    {
        // Properties
        public string Question { get; set; } = string.Empty;
        public string[] Answers { get; set; } = [];
        public int Correct { get; set; }

        // Methods
        public QuizQuestion Create()
        {
            return new QuizQuestion(Question, Answers, Correct);
        }
    }
}

