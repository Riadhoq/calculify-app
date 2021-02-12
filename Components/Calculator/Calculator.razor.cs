using System;
using System.Collections.Generic;
using Core.Models;

namespace Components
{
    public partial class Calculator {
        private string store = "0";
        private CalculatorModel calculator = new CalculatorModel();

        private string error = null;
        Dictionary<string, IOperation> operations = new Dictionary<string, IOperation> {
            {"+", new AddOperation()},
            {"-", new SubtractOperation()},
            {"x", new MultiplyOperation()},
            {"/", new DivideOperation()},
        };
        private Queue<string> history = new Queue<string>();

        private void HandleButtonClick(string num) {
            error = null;
            if(calculator.Display == "0" || calculator.Display == calculator.FirstNumber.ToString()) {
                calculator.Display = num;
            } else {
                calculator.Display += num;
            }
        }

        private void HandleDot() {
            if(calculator.Display.Contains(".")) {
                return; 
            } else calculator.Display += ".";
        }

        private void HandleOperatorClick(string op) {
            error = null;
            if(!string.IsNullOrEmpty(calculator.Display)){
                calculator.FirstNumber = double.Parse(calculator.Display);
                calculator.Display = calculator.FirstNumber.ToString();
            }
            calculator.SetOperation(operations[op]);
        }

        public void Calculate() {

            try {
                if(!string.IsNullOrEmpty(calculator.Display)){
                    calculator.SecondNumber = double.Parse(calculator.Display);
                }

                calculator.Result = calculator.Calculate();
                calculator.Display = calculator.Result.ToString();

                history.Enqueue(calculator.ToString());

                calculator.FirstNumber = calculator.Result.Value;

            } catch (Exception ex) {
                if(!calculator.hasOperation) {
                    error = "Please choose an operator before calculating";
                } else {
                    error = ex.Message;
                }
            }
        }

        public void Backspace() {
            if(calculator.Display.Length > 0 && calculator.Display != "0") {
                calculator.Display = calculator.Display.Remove(calculator.Display.Length - 1);
                if(calculator.Display.Length == 0) {
                    calculator.Display = "0";
                }
            }
        }

        public void AddStore() {
            store = (double.Parse(store) + double.Parse(calculator.Display)).ToString();
            calculator.Display = store;
        }

        public void SubtractStore() {
            store = (double.Parse(store) - double.Parse(calculator.Display)).ToString();
            calculator.Display = store;
        }

        public void CurrentStore() {
            calculator.Display = store;
        }

        public void EmptyStore() {
            store = "0";
            calculator.Display = store;
        }

        public void ToggleSign() {
            if(calculator.Display.Contains("-")){
                calculator.Display = calculator.Display.Substring(1);
            } else {
                calculator.Display = "-" + calculator.Display;
            }
        }

        public void Clear() {
            calculator = new CalculatorModel();
            error = null;
        }

        public void ClearAll() {
            Clear();
            store = "0";
            history = new Queue<string>();
        }

    }
    
}

