namespace TenthLabor.Model
{
    public class LoadedEventArgs(string loaded) : EventArgs
    {
        public string LoadedText { get; } = loaded;
    }
}

