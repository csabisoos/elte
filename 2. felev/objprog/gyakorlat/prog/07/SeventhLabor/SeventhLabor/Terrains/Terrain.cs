using SeventhLabor.Entities;

namespace SeventhLabor.Terrains
{
    public abstract class Terrain
    {
        public virtual bool IsMoveable(Aerial entity) { return false; }
        
        public virtual bool IsMoveable(Aquatic entity) { return false; }
        
        public virtual bool IsMoveable(Terrestial entity) { return false; }
    }
}

