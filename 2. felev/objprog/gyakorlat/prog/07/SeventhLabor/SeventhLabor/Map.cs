using SeventhLabor.Terrains;

namespace SeventhLabor
{
    public class Map
    {
        private Terrain[,] terrains;
        
        public int Rows => terrains.GetLength(0);
        public int Cols => terrains.GetLength(1);

        public Terrain this[int row, int col] => terrains[row, col];

        public Map(Terrain[,] terrains)
        {
            this.terrains = terrains;
        }
    }
}

