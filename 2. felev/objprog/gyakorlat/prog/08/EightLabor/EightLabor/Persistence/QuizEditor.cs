namespace EightLabor.Persistence
{
    public class QuizEditor
    {
        private QuizFileManager manager;
        private List<QuizQuestionDraft> questions;
 
        public List<QuizQuestionDraft> Questions => questions;
 
        public QuizEditor(string path)
        {
            manager = new(path);
            questions = manager.Load();
        }
 
        public void Edit(int index, int part, string text)
        {
            if (index >= questions.Count) return;
 
            switch (part)
            {
                case 0:
                    questions[index].Question = text;
                    break;
                case 1:
                    questions[index].Answers[0] = text;
                    break;
                case 2:
                    questions[index].Answers[1] = text;
                    break;
                case 3:
                    questions[index].Answers[2] = text;
                    break;
                case 4:
                    questions[index].Answers[3] = text;
                    break;
                case 5:
                    if (int.TryParse(text, out int correct)
                        && correct >= 0
                        && correct < 4)
                        questions[index].Correct = correct;
                    break;
            }
        }
        public void Save()
        {
            manager.Save(questions);
        }
    }
}

