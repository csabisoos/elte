namespace NinthLabor.Behavioral.Strategy;

public class StrategyFirst : IStrategy
{
    public void Method()
    {
        Console.WriteLine(nameof(Strategy) + ": " + nameof(StrategyFirst));
    }
}