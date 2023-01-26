//Girilen iki sayıyı karşılaştırıp büyük, küçük ya da eşit olma durumunu gösteren if-else örneği.
using System;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("2 tane sayı giriniz");
            double number = Convert.ToDouble(Console.ReadLine());
            double numberA = Convert.ToDouble(Console.ReadLine());

            if (number > numberA)
            {
                Console.WriteLine($"{number} > {numberA}");
            }
            if (number < numberA)
            {
                Console.WriteLine($"{number} < {numberA}");
            }
            else
            {
                Console.WriteLine($"{number} = {numberA}");
            }
        }
    }
}
