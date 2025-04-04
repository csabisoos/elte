namespace EightLabor.Persistence
{
    public class QuizFileManager
    {
        // Fields
        private readonly string path;

        // Porperties
        public QuizFileManager(string path)
        {
            this.path = path;
        }

        // Methods
        public List<QuizQuestionDraft> Load()
        {
            StreamReader reader = new(path);
            List<QuizQuestionDraft> questions = [];
            QuizQuestionDraft question;

            while (!reader.EndOfStream)
            {
                question = new();
                question.Question = reader.ReadLine();
                question.Answers = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    question.Answers[i] = reader.ReadLine();
                }
                question.Correct = int.Parse(reader.ReadLine());
                
                questions.Add(question);
            }

            return questions;
        }

        public void Save(List<QuizQuestionDraft> questions)
        {
            StreamWriter writer = new(path);

            foreach (QuizQuestionDraft question in questions)
            {
                writer.WriteLine(question.Question);
            }
        }
    }
}

