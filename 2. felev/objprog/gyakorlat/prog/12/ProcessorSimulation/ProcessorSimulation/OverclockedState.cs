namespace ProcessorSimulation
{
    public class OverclockedState : ProcessorState
    {
        public OverclockedState(Processor processor) : base(processor) {}

        public override void Run()
        {
            processor.ExecuteInstructions(processor.Count);
            processor.State = new OverheatedState(processor);
        }
    }
}

