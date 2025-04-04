namespace EightLabor.View
{
    public class EditorView
    {
        private QuizEditor editor;
 
        public EditorView(QuizEditor editor)
        {
            this.editor = editor;
        }
 
        public void Run()
        {
            string input;
            int index;
            int part;
            string text;
            do
            {
                Refresh();
 
                input = Console.ReadLine()!;
                if (!int.TryParse(input, out index)) continue;
 
                input = Console.ReadLine()!;
                if (!int.TryParse(input, out part)) continue;
 
                text = Console.ReadLine()!;
                editor.Edit(index - 1, part - 1, text);
            } while (input != "");
 
            editor.Save();
            Console.Clear();
            Console.WriteLine("Saved!");
        }
        private void Refresh()
        {
            Console.Clear();
            foreach (QuizQuestionDraft question in editor.Questions)
            {
                Console.WriteLine(question.Question);
                foreach (string answer in question.Answers)
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine(question.Correct);
                Console.WriteLine();
            }
        }
    }
}

