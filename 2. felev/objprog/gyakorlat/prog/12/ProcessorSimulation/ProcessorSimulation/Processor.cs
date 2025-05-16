namespace ProcessorSimulation
{
    public class Processor
    {
        // Fields
        private List<Instruction> instructions;
        public int Count
        {
            get { return instructions.Count; }
        }
        private List<Register> registers { get; }
        public ProcessorState State { get; set; }
        
        // Constructors
        public Processor(int count, List<string> names)
        {
            State = new NormalState(this);
            instructions = new List<Instruction>();
            registers = new List<Register>(count);
            for (int i = 0; i < count; i++)
            {
                registers[i] = new Register(names[i]);
            }
        }
        
        // Methods
        public void AddInstruction(IInstruction instruction, string name, int value)
        {
            (Register register, bool found) = SelectRegisterByName(name);
            if (found)
            {
                instructions.Add(new Instruction(instruction, register, value));
            }
        }
        
        public void ExecuteInstructions()
        {
            ExecuteInstructions(1);
        }

        public void ExecuteInstructions(int repeat)
        {
            foreach (var instruction in instructions)
            {
                for (int i = 0; i < repeat; i++)
                {
                    instruction.Execute();
                }
            }
        }

        public void Run()
        {
            State.Run();
            instructions.Clear();
        }

        public void Restart()
        {
            State = new NormalState(this);
            instructions.Clear();
            foreach (var register in registers)
            {
                register.Value = 0;
            }
        }

        public void Overclock()
        {
            State = new OverclockedState(this);
        }

        public (Register?, int, bool) MaxNotEmptyRegister()
        {
            Register register = registers.OrderByDescending(x => x.Value != 0).First();
            if (register != null)
            {
                return (register, true);
            }
            return (null, false);
        }

        public (Register?, int, bool) MinNotEmptyRegister()
        {
            Register register = registers.OrderBy(x => x.Value != 0).First();
            if (register != null)
            {
                return (register, true);
            }
            return (null, false);
        }

        
        
        public (Register, bool) SelectRegisterByName(string name)
        {
            return registers.Select(x => x.Name == name);
        }
    }
}

