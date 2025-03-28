using SeventhLabor.Entities;

namespace SeventhLabor.Terrains
{
    public class Mountain : Terrain
    {
        public override bool IsMoveable(Aerial entity) { return true; }
    }
}

