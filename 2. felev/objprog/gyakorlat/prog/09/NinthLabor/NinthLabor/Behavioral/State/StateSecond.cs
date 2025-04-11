namespace NinthLabor.Behavioral.State;

public class StateSecond
{
    public void MethodFirst()
    {
        Console.WriteLine(nameof(State) + ": " + nameof(StateSecond) + ": " + nameof(MethodFirst));
        StateSecond state = new();
        state.Class = @class;
        @class.State = state;
    }
    
    public void MethodSecond()
    {
        Console.WriteLine(nameof(State) + ": " + nameof(StateSecond) + ": " + nameof(MethodSecond));
        StateSecond state = new();
        state.Class = @class;
        @class.State = state;
    }
}