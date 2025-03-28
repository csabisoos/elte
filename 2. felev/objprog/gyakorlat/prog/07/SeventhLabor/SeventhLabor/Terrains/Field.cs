using SeventhLabor.Entities;

namespace SeventhLabor.Terrains
{
    public class Field : Terrain
    {
        public override bool IsMoveable(Aerial entity) { return true; }
        
        public override bool IsMoveable(Terrestial entity) { return true; }
    }
}

