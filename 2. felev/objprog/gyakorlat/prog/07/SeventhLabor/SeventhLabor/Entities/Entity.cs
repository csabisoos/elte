namespace SeventhLabor.Entities
{
    public abstract class Entity
    {
        protected int row;
        protected int col;
        protected Map map;

        public int Row => row;
        public int Col => col;

        protected Entity(Map map, int row, int col)
        {
            this.map = map;
            this.col = col;
            this.row = row;
        }

        public abstract void Move(int row, int col);

        protected bool IsInsideMap(int row, int col)
        {
            return row >= 0 && col >= 0 && row < map.Rows && col < map.Cols;
        }

        protected void ChangePosition(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}

