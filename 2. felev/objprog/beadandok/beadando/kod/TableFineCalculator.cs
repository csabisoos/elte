public class TableFineCalculator : IFineCalculator
{
  public decimal GetDailyFine(BookGenre genre, int copyCount)
  {
    bool rare = copyCount < 10;
    bool few  = copyCount < 100 && copyCount >= 10;

    return genre switch
    {
      BookGenre.Science    => rare ? 100m : few ? 60m  : 20m,
      BookGenre.Literature => rare ?  50m : few ? 30m  : 10m,
      BookGenre.Youth      => rare ?  30m : few ? 10m  :  5m,
      _                    => throw new ArgumentOutOfRangeException(nameof(genre))
    };
  }
}
