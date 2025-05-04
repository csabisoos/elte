namespace HF10
{
    public abstract class Gift
    {
        // Fields
        private Size size;
        private TargetShot? targetShot { get; set; }

        // Constructors
        public Gift()
        {
            targetShot = null;
        }
        public Gift(Size size)
        {
            this.size = size;
        }
        
        // Properties
        public TargetShot? GetTargetShot()
        {
            return targetShot;
        }

        public void SetTargetShot(TargetShot target)
        {
            this.targetShot = target;
        }
        
        // Methods
        public int Value()
        {
            return Pont() * size.Multi();
        }

        public abstract int Pont();
    }
}

