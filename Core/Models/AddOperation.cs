namespace Core.Models
{
    public class AddOperation : IOperation
    {
        public string Sign() => "+";

        public double? Compute(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}