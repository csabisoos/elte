namespace ProcessorSimulation
{
    public class Move : IInstruction
    {
        private Move instance;
        
        private Move(){}

        public Move Instance()
        {
            return instance ?? new Move();
        }

        public void Execute(Register register, int value)
        {
            register.Value = value;
        }
    }
}

