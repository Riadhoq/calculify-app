using System.Collections.Generic;

namespace Core.Models
{
    public class CalculatorModel {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Display { get; set; }
        public double? Result { get; set; }
        public IOperation Operation { get; private set; }
        public bool hasOperation { get; private set ;}

        public CalculatorModel() {
            Display = "0";
            FirstNumber = 0;
            SecondNumber = 0;
            Result = 0;
        }
        public double? Calculate() {
            return Operation.Compute(FirstNumber, SecondNumber);
        }

        public void SetOperation(IOperation operation) {
            Operation = operation;
            hasOperation = true;
        }

        public override string ToString()
        {
            return $"{this.FirstNumber.ToString()} {Operation.Sign()} {this.SecondNumber.ToString()} = {this.Result}";
        }

    }
}