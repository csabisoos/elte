using NinthLabor.Behavioral.Strategy;

namespace NinthLabor.Behavioral.State;

public class Class
{
    private IState state;
    public IState State
    {
        set { state = value; }
    }

    public Class(IState state)
    {
        this.state = state;
    }

    public void MethodFirst()
    {
        state.MethodFirst();
    }

    public void MethodSecond()
    {
        state.MethodSecond();
    }
}