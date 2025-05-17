public class GenreFineMultiplier : IFineMultiplierByGenre
{
    public decimal GetMultiplier(BookGenre genre)
        => genre switch
        {
            BookGenre.Science    => 20m,
            BookGenre.Literature => 10m,
            BookGenre.Youth      => 5m,
            _                    => throw new ArgumentOutOfRangeException()
        };
}