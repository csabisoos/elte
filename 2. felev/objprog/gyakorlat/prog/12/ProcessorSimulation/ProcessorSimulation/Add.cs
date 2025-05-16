namespace ProcessorSimulation
{
    public class Add : IInstruction
    {
        private Add instance;
        
        private Add(){}

        public Add Instance()
        {
            return instance ?? new Add();
        }

        public void Execute(Register register, int value)
        {
            register.Value += value;
        }
    }
}

