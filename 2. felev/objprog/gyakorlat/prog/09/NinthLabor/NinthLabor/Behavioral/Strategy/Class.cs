namespace NinthLabor.Behavioral.Strategy;

public class Class
{
    private IStrategy strategy;
    
    public IStrategy Strategy
    {
        set { strategy = value; }
    }
    
    public Class(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void Method()
    {
        strategy.Method();
    }
}