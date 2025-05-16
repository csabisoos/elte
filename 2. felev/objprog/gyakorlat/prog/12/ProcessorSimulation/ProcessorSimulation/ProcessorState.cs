namespace ProcessorSimulation
{
    public abstract class ProcessorState
    {
        protected Processor processor;
        
        protected ProcessorState(Processor processor)
        {
            this.processor = processor;
        }

        public abstract void Run();
    }
}

