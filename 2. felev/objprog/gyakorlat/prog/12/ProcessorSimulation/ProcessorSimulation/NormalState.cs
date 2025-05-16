namespace ProcessorSimulation
{
    public class NormalState : ProcessorState
    {
        public NormalState(Processor processor) : base(processor){}

        public override void Run()
        {
            processor.ExecuteInstructions();
        }
    }
}

