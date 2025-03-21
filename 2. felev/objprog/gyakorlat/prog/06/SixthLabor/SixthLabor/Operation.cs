namespace SixthLabor
{
    public class Operation
    {
        // Fields
        private readonly double operand;
        private Operators @operator;
        
        // Properties
        public double Operand => operand;
        public Operators Operator => @operator;
        
        // Constructors
        public Operation(Operators @operator, double operand)
        {
            this.operand = operand;
            this.@operator = @operator;
        }
        
        // Methods
        public double Calculate(double number)
        {
            switch (@operator)
            {
                case Operators.Addition:
                    return number + operand;
                case Operators.Subtraction:
                    return number - operand;
                case Operators.Multiplication:
                    return number * operand;
                case Operators.Division:
                    return number / operand;
                default:
                    throw new NotImplementedException("Calculation with this operator is not implemented!");
                    break;
            }
        }
    }
}

