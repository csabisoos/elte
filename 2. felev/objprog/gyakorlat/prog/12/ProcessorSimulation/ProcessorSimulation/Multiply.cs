namespace ProcessorSimulation
{
    public class Multiply
    {
        private Multiply instance;
        
        private Multiply(){}

        public Multiply Instance()
        {
            return instance ?? new Multiply();
        }

        public void Execute(Register register, int value)
        {
            register.Value *= value;
        }   
    }
}

