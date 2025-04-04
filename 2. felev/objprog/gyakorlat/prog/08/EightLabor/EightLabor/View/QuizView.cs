namespace EightLabor.View
{
    public class QuizView : IRunnable
    {
        // Fields
        private QuizModel model;
        
        // Porperties
        
        // COnstructors
        public QuizView(QuizModel model)
        {
            this.model = model;
        }
        
        // Methods
        public void Run()
        {
            ConsoleKey input;
            bool done = false;
            
            Console.CursorVisible = false;
            do
            {
                Console.Clear();
                QuizQuestion question = model.CurrentQuestion;
                Console.WriteLine($"|{question.Question}|");
                /*foreach (string answer in question.Answers)
                {
                    Console.WriteLine($"-{answer}");
                }*/

                for (int i = 0; i < question.Answers.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {question.Answers[i]}");
                }
                
                input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("Result: \n" + $"{model.Points}/{model.QuestionCount}");
                        done = true;
                        break;
                    case ConsoleKey.RightArrow:
                        model.Next();
                        break;
                    case ConsoleKey.LeftArrow:
                        model.Previous();
                        break;
                    case ConsoleKey.D1:
                        model.Guess(0);
                        break;
                    case ConsoleKey.D2:
                        model.Guess(1);
                        break;
                    case ConsoleKey.D3:
                        model.Guess(2);
                        break;
                    case ConsoleKey.D4:
                        model.Guess(3);
                        break;
                }
            } while (!done);
        }
    }
}

