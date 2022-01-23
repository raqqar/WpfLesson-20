using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLesson_20.Models
{
    internal class CalcModel
    {
        

        private string result;



        public CalcModel(string firstOperand, string secondOperand, string operation)
        {
            ValidateOperand(firstOperand);
            ValidateOperand(secondOperand);
            ValidateOperation(operation);

            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
            result = string.Empty;
        }

        public CalcModel(string firstOperand, string operation)
        {
            ValidateOperand(firstOperand);
            ValidateOperation(operation);

            FirstOperand = firstOperand;
            SecondOperand = string.Empty;
            Operation = operation;
            result = string.Empty;
        }

        public CalcModel()
        {
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            Operation = string.Empty;
            result = string.Empty;
        }


        public string FirstOperand { get; set; }
        public string SecondOperand { get; set; }
        public string Operation { get; set; }
        public string Result { get { return result; } }

        public void CalculateResult()
        {
            ValidateData();

            try
            {
                switch (Operation)
                {
                    case ("+"):
                        result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case ("-"):
                        result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case ("*"):
                        result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case ("/"):
                        result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case ("1/x"):
                        result = (1 / Convert.ToDouble(FirstOperand)).ToString();
                        break;

                    case ("^2"):
                        result = Math.Pow(Convert.ToDouble(FirstOperand), 2).ToString();
                        break;

                    case ("sqrt"):
                        result = Math.Sqrt(Convert.ToDouble(FirstOperand)).ToString();
                        break;

                }
            }
            catch (Exception)
            {
                result = "Error whilst calculating";
                throw;
            }
        }

        private void ValidateData()
        {
            switch (Operation)
            {
                case "/":
                case "*":
                case "-":
                case "+":
                case "%":
                    ValidateOperand(FirstOperand);
                    ValidateOperand(SecondOperand);
                    break;
                case ("1/x"):
                case ("^2"):
                case ("sqrt"):
                    ValidateOperand(FirstOperand);
                    break;
                default:
                    result = "Unknown operation: " + Operation;
                    throw new ArgumentException("Unknown Operation: " + Operation, "operation");
            }
        }

        private void ValidateOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch (Exception)
            {
                result = "Invalid number: " + operand;
                throw;
            }
        }

        private void ValidateOperation(string operation)
        {
            switch (operation)
            {
                case "/":
                case "*":
                case "-":
                case "+":
                case ("1/x"):
                case ("^2"):
                case ("sqrt"):
                case ("%"):
                    break;
                default:
                    result = "Unknown operation: " + operation;
                    throw new ArgumentException("Unknown Operation: " + operation, "operation");
            }
        }

    }
}

