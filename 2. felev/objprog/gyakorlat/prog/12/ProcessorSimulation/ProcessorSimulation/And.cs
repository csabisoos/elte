namespace ProcessorSimulation
{
    public class And
    {
        private And instance;
        
        private And(){}

        public And Instance()
        {
            return instance ?? new And();
        }

        public void Execute(Register register, int value)
        {
            register.Value &= value;
        }
    }
}

