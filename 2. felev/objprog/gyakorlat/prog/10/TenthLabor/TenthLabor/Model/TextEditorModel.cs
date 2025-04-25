using TenthLabor.Persistence;


namespace TenthLabor.Model
{
    public class TextEditorModel
    {
        #region Fields
        private int top;
        private int left;
        private bool saved;
        private string path;
        private List<List<char>> text;
        private TextEditorPersistence persistence;
        #endregion

        #region Constructors
        
        public TextEditorModel(string path)
        {
            persistence = new();
            this.path = path;
            text = [];
        }
        
        #endregion Constructors

        #region Events

        public event EventHandler<PointerEventArgs>? PointerMoved;
        public event EventHandler<LoadedEventArgs>? TextLoaded;
        public event EventHandler<ModifiedEventArgs>? CharacterRemoved;
        public event EventHandler? TextModified;
        public event EventHandler? TextSaved;
        public event EventHandler? EditorClosed;

        #endregion Events

        #region Event Methods

        public void OnPointerMoved()
        {
            PointerMoved?.Invoke(this, new(left, top));
        }

        public void OnCharacterRemoved()
        {
            CharacterRemoved?.Invoke(this, new(modified));
        }

        public void OnEditorClosed()
        {
            EditorClosed?.Invoke(this, EventArgs.Empty);
        }

        public void OnTextLoaded()
        {
            string loaded = string.Concat(text.Select(line => new string(line.ToArray()) + "\n"));
            TextLoaded?.Invoke(this, new(loaded));
        }

        #endregion Event Methods

        #region Methods
        public void Edit(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow: MovePointerLeft(); break;
                case ConsoleKey.UpArrow: MovePointerUp(); break;
                case ConsoleKey.RightArrow: MovePointerRight(); break;
                case ConsoleKey.DownArrow: MovePointerDown(); break;
                case ConsoleKey.Backspace: RemoveCharacter(); break;
                case ConsoleKey.Enter: SaveText(); break;
                case ConsoleKey.Escape: OnEditorClosed(); break;
                default: WriteCharacter(key.KeyChar); break;
            }
        }
        public void Load()
        {
            TextEditorModelDraft draft = persistence.LoadFile(path);
            
            left = draft.Left;
            top = draft.Top;
            saved = draft.Saved;
            path = draft.Path;
            text = draft.Text;
            
            OnTextLoaded();
            MovePointer(0, 0);
        }
        public void Save()
        {
            string parsed = string.Concat(text.Select(line => new string(line.ToArray()) + "\n"));
            persistence.SaveFile(path, parsed);
            // TODO OnTextSaved();
        }
     
        private void MovePointer(int left, int top)
        {
            this.left = left;
            this.top = top;
     
            // TODO OnPointerMoved();
        }
        private void MovePointerLeft()
        {
            if (left > 0)
                MovePointer(left - 1, top);
        }
        private void MovePointerUp()
        {
            if (top > 0 && text[top - 1].Count < left)
                MovePointer(text[top - 1].Count, top - 1);
            else if (top > 0)
                MovePointer(left, top - 1);
        }
        private void MovePointerRight()
        {
            if (text[top].Count > left)
                MovePointer(left + 1, top);
        }
        private void MovePointerDown()
        {
            if (text.Count > top + 1 && text[top + 1].Count < left)
                MovePointer(text[top + 1].Count, top + 1);
            else if (text.Count > top + 1)
                MovePointer(left, top + 1);
        }
        private void RemoveCharacter()
        {
            saved = false;
            int position = left;
     
            if (left > 0)
            {
                text[top].RemoveAt(left - 1);
                MovePointer(0, top);
                // TODO OnCharacterRemoved(new string([.. text[top]]) + ' ');
                MovePointer(position - 1, top);
            }
            else if (left == 0 && text[top].Count <= 1 && text.Count - 1 == top && text.Count > 1)
            {
                // int length = text[top].Count;
                text.RemoveAt(text.Count - 1);
                // TODO OnCharacterRemoved(" ");
                MovePointer(text[top - 1].Count, top - 1);
            }
            else if (left == 0 && text[top].Count <= 1)
            {
                // TODO OnCharacterRemoved(" ");
                MovePointer(0, top);
            }
     
            // TODO OnTextModified();
        }
        private void SaveText()
        {
            if (saved && text.Count - 1 == top)
            {
                text.Add([]);
                saved = false;
                // TODO OnTextModified();
                MovePointer(0, top + 1);
            }
            else if (!saved)
            {
                Save();
                saved = true;
                MovePointer(left, top);
            }
        }
        private void WriteCharacter(char character)
        {
            if (text[top].Count <= left)
            {
                text[top].Add(character);
            }
            else
            {
                text[top][left] = character;
            }
     
            saved = false;
            MovePointer(left + 1, top);
            // TODO OnTextModified();
        }
        #endregion
    }
}

