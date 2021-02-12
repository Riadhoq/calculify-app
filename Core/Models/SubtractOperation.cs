namespace Core.Models
{
    public class SubtractOperation : IOperation
    {
        public string Sign() => "-";
        public double? Compute(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}