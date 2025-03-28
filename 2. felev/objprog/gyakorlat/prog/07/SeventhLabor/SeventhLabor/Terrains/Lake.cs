using SeventhLabor.Entities;

namespace SeventhLabor.Terrains
{
    public class Lake : Terrain
    {
        public override bool IsMoveable(Aerial entity) { return true; }
        
        public override bool IsMoveable(Aquatic entity) { return true; }
    }
}

