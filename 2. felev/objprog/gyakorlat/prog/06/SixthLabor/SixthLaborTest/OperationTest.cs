using SixthLabor;

namespace SixthLaborTest
{
    [TestClass]
    public sealed class OperationTest
    {
        [TestMethod]
        public void Operator_Initilalized_ReturnsOperator()
        {
            Operation operation = new(Operators.Addition, 0);
            
            Operators @operator = operation.Operator;
            
            Assert.AreEqual(Operators.Addition, @operator);
        }
        
        [TestMethod]
        public void Calculate_Addition_ReturnsSumOfOperands()
        {
            Operation operation = new(Operators.Addition, 2);

            double sum = operation.Calculate(3);
            
            Assert.AreEqual(5, sum);
        }

        [TestMethod]
        public void Calculate_Subtraction_ReturnsSubOfOperands()
        {
            Operation operation = new(Operators.Subtraction, 2);

            double sub = operation.Calculate(3);
            
            Assert.AreEqual(1, sub);
        }
        
        [TestMethod]
        public void Calculate_Multiplication_ReturnsMultOfOperands()
        {
            Operation operation = new(Operators.Multiplication, 2);

            double sub = operation.Calculate(3);
            
            Assert.AreEqual(6, sub);
        }

        [TestMethod]
        public void Calculate_Division_ReturnsDivOfOperands()
        {
            Operation operation = new(Operators.Division, 2);

            double sub = operation.Calculate(2);
            
            Assert.AreEqual(1, sub);
        }
    }
}

