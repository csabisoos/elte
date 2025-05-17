public class StockFineMultiplier : IFineMultiplierByStock
{
    public decimal GetMultiplier(int copyCount)
        => copyCount switch
        {
            < 10   => 100m,  // ritka
            < 100  => 30m,   // kevés
            _      => 20m    // sok
        };
}
