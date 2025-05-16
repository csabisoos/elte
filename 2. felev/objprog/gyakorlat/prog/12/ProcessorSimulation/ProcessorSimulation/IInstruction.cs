namespace ProcessorSimulation
{
    public interface IInstruction
    {
        public void Execute(Register register, int value);
    }
}

