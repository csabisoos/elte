using TenthLabor.Model;
using TenthLabor.View;

namespace TenthLabor
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditorModel model = new(@"/Users/csabasoos/Desktop/elte/2. felev/objprog/gyakorlat/prog/10/TenthLabor/TenthLabor/file.txt");
            TextEditorView view = new(model);
            view.Run();
        }
    }
}

