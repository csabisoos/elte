namespace TenthLabor.Model
{
    public class PointerEventArgs(int left, int top) : EventArgs
    {
        public int Left { get; } = left;
        public int Top { get; } = top;
    }
}

