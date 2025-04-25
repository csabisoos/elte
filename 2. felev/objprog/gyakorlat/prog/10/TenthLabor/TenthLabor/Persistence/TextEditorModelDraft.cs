namespace TenthLabor.Persistence
{
    public class TextEditorModelDraft
    {
        public TextEditorModelDraft()
        {
            
        }
        public int Top { get; set; }
        public int Left { get; set; }
        public bool Saved { get; set; }
        public string Path { get; set; } = "";
        public List<List<char>> Text { get; set; } = [];
    }
}

