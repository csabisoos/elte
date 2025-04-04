using EightLabor.Persistence;
using EightLabor.View;
//using EightLabor.Model;

namespace EightLabor
{
    class Program
    {
        static void Main(string[] args)
        {
            QuizModel quizModel = new(@"/Users/csabasoos/Desktop/elte/2. felev/objprog/gyakorlat/prog/08/EightLabor/EightLabor/quiz.txt");
            QuizView quizView = new(quizModel);

            //QuizEditor editorModel = new(@"/Users/csabasoos/Desktop/elte/2. felev/objprog/gyakorlat/prog/08/EightLabor/EightLabor/quiz.txt");

            //EditorView editorView = new(editorModel);
            
            quizView.Run();
        }
    }
}

