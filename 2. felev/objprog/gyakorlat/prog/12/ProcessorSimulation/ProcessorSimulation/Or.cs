namespace ProcessorSimulation
{
    public class Or
    {
        private Or instance;
        
        private Or(){}

        public Or Instance()
        {
            return instance ?? new Or();
        }

        public void Execute(Register register, int value)
        {
            register.Value |= value;
        }
    }
}

