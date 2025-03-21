namespace SixthLabor
{
    public class Equation
    {
        // Fields
        private readonly double starter;
        private double result;
        private List<Operation> operations;

        // Properties
        public double Starter => starter;
        public double Result => result;
        public Operation this[int index] => operations[index];
        
        // Constructors
        public Equation(double starter)
        {
            this.starter = starter;
            result = starter;
            operations = [];
        }
        
        // Methods
        public void Add(Operation operation)
        {
            operations.Add(operation);
            result = operation.Calculate(result);
        }

        public int CountOperator(Operators @operator)
        {
            int count = 0;
            foreach (Operation operation in operations)
            {
                if (operation.Operator == @operator)
                {
                    ++count;
                }
            }

            return count;
        }

        public int CountOperand(double operand)
        {
            return operations.Count(o => o.Operand == operand);
        }

        public double MaxOperand()
        {
            return operations.Max(o => o.Operand);
        }

        public double MinOperand()
        {
            return operations.Min(o => o.Operand);
        }
    }
}

