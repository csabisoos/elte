namespace HF1;

public class Labirynth
{
    private int n;
    private int m;
    private Content[,] map;

    public Labirynth(Content[,] map)
    {
        this.n = map.GetLength(0);
        this.m = map.GetLength(1);
        this.map = map;
    }

    public Content LookAt(int x, int y, Direction dir)
    {
        if (!(0<=x+dir.x && x+dir.x<=n && 0<=y+dir.y && y+dir.y<=m))
        {
            throw new Exception("Invalid coordinates");
        }

        return this.map[x + dir.x, y + dir.y];
    }

    public void Collect(int x, int y)
    {
        if (this.map[x,y] != Content.Treasure)
        {
            throw new Exception("No treasure to collect");
        }

        this.map[x, y] = Content.Empty;
    }
}