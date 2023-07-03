//The user will type 5 different float numbers. The application will sort these numbers from smallest to largest.
using System;

namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type 5 different float numbers\n");

            float number1 = Convert.ToSingle(Console.ReadLine().Trim());
            float number2 = Convert.ToSingle(Console.ReadLine().Trim());
            float number3 = Convert.ToSingle(Console.ReadLine().Trim());
            float number4 = Convert.ToSingle(Console.ReadLine().Trim());
            float number5 = Convert.ToSingle(Console.ReadLine().Trim());

            float[] numbers = { number1, number2, number3, number4, number5 };

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int y = 0; y < (numbers.Length - 1); y++)
                {
                    if (numbers[y] > numbers[y + 1])
                    {
                        float numberTemp = numbers[y + 1];
                        numbers[y + 1] = numbers[y];
                        numbers[y] = numberTemp;
                    }

                }
            }
            Console.WriteLine("\nFrom smallest to largest");
            foreach (float item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
