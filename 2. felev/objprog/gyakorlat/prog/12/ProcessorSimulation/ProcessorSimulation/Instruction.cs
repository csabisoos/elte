namespace ProcessorSimulation
{
    public class Instruction
    {
        // Fields
        private int value;
        private Register register;
        private IInstruction instruction;
        
        // Constructors
        public Instruction(IInstruction instruction, Register register, int value)
        {
            this.instruction = instruction;
            this.register = register;
            this.value = value;
        }

        public void Execute()
        {
            instruction.Execute(register, value);
        }
    }
}

