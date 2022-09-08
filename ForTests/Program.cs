using System;
using System.Linq;

namespace ForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var actions = new Actions();
            int[] numbers = new int[100];
            for (int i = numbers.Length; i > 0; i--)
            {
                numbers[^i] = i;
            }

            var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
            var negativeNumbers = numbers.Select(x => x * -1).ToArray();
            var orderNumbers = numbers.OrderBy(x => x).ToArray();
            var numbersZero = numbers.Select(x => actions.DeleteZeros(x)).ToArray();
        }
    }

    public class Actions
    {
        public int DeleteZeros(int number)
        {
            if (number % 10 == 0)
                return 0;
            else
                return number;
        }
    }
}