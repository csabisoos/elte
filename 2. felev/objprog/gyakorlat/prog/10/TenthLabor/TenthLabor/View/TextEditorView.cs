using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using TenthLabor.Model;

namespace TenthLabor.View
{
    public class TextEditorView
    {
        #region Fields

        private TextEditorModel model;
        private bool run;
        
        #endregion Fields

        #region Constructors

            public TextEditorView(TextEditorModel model)
            {
                this.model = model;
                
                model.TextLoaded += (_, e) => Console.Write(e.LoadedText);
                model.CharacterRemoved += (_, e) => Console.Write(e.ModifiedText);
                model.PointerMoved += (_, e) => Console.SetCursorPosition(e.Left, e.Top);
                model.EditorClosed += EndRun;
                model.TextLoaded+= (_, e) => Console.Write(e.LoadedText);
                model.TextModified += (_, _) =>
                {
                    int left = Console.CursorLeft;
                    int top = Console.CursorTop;
                    Console.SetCursorPosition(Console.WindowWidth - 1, 0);
                    Console.WriteLine('*');
                    Console.SetCursorPosition(left, top);
                };
            }
            
        #endregion
        
        private void EndRun(object? sender, EventArgs e)
        {
            run = false;
        }

        public void Run()
        {
            model.Load();

            run = true;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                model.Edit(key);
            } while (run);
        }
    }
}

