public static class FineCalculatorFactory
{
    public static IFineCalculator Create() => new TableFineCalculator();
}
