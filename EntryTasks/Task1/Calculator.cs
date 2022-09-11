using System;

namespace EntryTasks.Task1
{
    public class Calculator
    {
        public double SetFirstNumber()
        {
            double firstNumber = 0;
            Console.WriteLine("Enter the valid first number");
            try
            {
                firstNumber = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Input is invalid.");
                SetFirstNumber();
            }
            return firstNumber;
        }
        public double SetSecondNumber()
        {
            double secondNumber = 0;
            Console.WriteLine("Enter the valid second number");
            try
            {
                secondNumber = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Input is invalid.");
                SetSecondNumber();
            }
            return secondNumber;
        }
        public double Calculate(double Num1, double Num2)
        {
            double result = 0;
            Console.WriteLine("Choose action to do: + ; -; / ; *");
            string action = Console.ReadLine();
            try
            {
                switch (action)
                {
                    case "+": result = Num1 + Num2; break;
                    case "-": result = Num1 - Num2; break;
                    case "*": result = Num1 * Num2; break;
                    case "/":
                        if (Num2 == 0) { Console.WriteLine("Division by 0 is impossible"); Calculate(Num1, Num2); }
                        result = Num1 / Num2; break;
                    default:
                        Console.WriteLine("Input is invalid");
                        Calculate(Num1, Num2);
                        break;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Calculate(Num1, Num2);
            }
            return result;
        }
        public void ShowResult(double result) => Console.WriteLine($"Your result is {result}");
    }
}