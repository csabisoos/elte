namespace TenthLabor.Model
{
    public class ModifiedEventArgs(string loaded) : EventArgs
    {
        public string ModifiedText { get; } = loaded;
    }
}

