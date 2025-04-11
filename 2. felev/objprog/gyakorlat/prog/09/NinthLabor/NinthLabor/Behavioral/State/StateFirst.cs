namespace NinthLabor.Behavioral.State;

public class StateFirst : IState
{

    private Class @class;
    
    public Class Class
    {
        set { @class = value; }
    }
    public void MethodFirst()
    {
        Console.WriteLine(nameof(State) + ": " + nameof(StateFirst) + ": " + nameof(MethodFirst));
        StateSecond state = new();
        state.Class = @class;
        @class.State = state;
    }
    
    public void MethodSecond()
    {
        Console.WriteLine(nameof(State) + ": " + nameof(StateFirst) + ": " + nameof(MethodSecond));

    }
}