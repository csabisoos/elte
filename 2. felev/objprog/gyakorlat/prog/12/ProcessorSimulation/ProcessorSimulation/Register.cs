namespace ProcessorSimulation
{
    public class Register
    {
        // Fields
        public string Name { get;}
        public int Value { get; set; }
            
        // Constructors
        public Register(string name)
        {
            this.Name = name;
        }
    }
}

