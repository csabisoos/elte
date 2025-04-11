namespace NinthLabor.Behavioral.Strategy;

public class StrategySecond : IStrategy
{
    public void Method()
    {
        Console.WriteLine(nameof(Strategy) + ": " + nameof(StrategySecond));
    }
}