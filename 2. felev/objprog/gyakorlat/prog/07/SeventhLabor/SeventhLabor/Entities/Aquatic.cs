namespace SeventhLabor.Entities
{
    public class Aquatic : Entity
    {
        public Aquatic(Map map, int row, int col) : base(map, row, col) { }

        public override void Move(int row, int col)
        {
            int newRow = base.row + row;
            int newCol = base.col + col;

            if (IsInsideMap(newRow, newCol) && map[newRow, newCol].IsMoveable(this))
            {
                ChangePosition(newRow, newCol);
            }
        }
    }
}

