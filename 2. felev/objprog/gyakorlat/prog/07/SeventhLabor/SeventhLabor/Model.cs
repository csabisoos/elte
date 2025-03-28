using SeventhLabor.Entities;
using SeventhLabor.Terrains;

namespace SeventhLabor
{
    public class Model
    {
        private int counter;
        private Entity entity;
        private readonly Map map;

        public Entity Entity => entity;
        
        public Map Map => map;

        public Model(Terrain[,] terrains, int row, int col)
        {
            map = new(terrains);
            entity = new Terrestial(map, row, col);
        }

        public void Move(int row, int col)
        {
            entity.Move(row, col);
        }

        public void Transform()
        {
            int row = entity.Row;
            int col = entity.Col;

            switch (counter)
            {
                case 0:
                    entity = new Aerial(map, row, col);
                    break;
                case 1:
                    entity = new Aquatic(map, row, col);
                    break;
                case 2:
                    entity = new Terrestial(map, row, col);
                    break;
                
            }

            counter = (counter + 1) % 3;
        }
    }
}

