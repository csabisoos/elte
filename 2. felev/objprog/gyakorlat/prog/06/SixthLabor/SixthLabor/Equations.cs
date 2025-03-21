namespace SixthLabor
{
    public class Equations
    {
        // Fields
        private List<Equation> equations;
        
        // Properties
        public int Count => equations.Count;
        public Equation this[int index] => equations[index];
        
        // Constructors
        public Equations()
        {
            equations = new List<Equation>();
        }
        
        // Methods
        public void Add(Equation equation)
        {
            equations.Add(equation);
        }

        public int CountOperator(Operators @operator)
        {
            return equations.Sum(e => e.CountOperator(@operator));
        }
        
        public int CountOperand(double operand)
        {
            return equations.Sum(e => e.CountOperand(operand));
        }
        
        public double MaxOperand()
        {
            return equations.Max(e => e.MaxOperand());
        }
        
        public double MinOperand()
        {
            return equations.Min(e => e.MinOperand());
        }
    }
}

