namespace Core.Models
{
    public interface IOperation
    {
        string Sign();
        double? Compute(double firstNumber, double secondNumber);
    }
}