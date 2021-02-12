namespace Core.Models
{
    public class MultiplyOperation : IOperation
    {
        public string Sign() => "x";
        public double? Compute(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}