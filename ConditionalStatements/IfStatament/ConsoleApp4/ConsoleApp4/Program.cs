//Kullanıcının girdiği sayının pozitif, negatif yada sıfır olduğunu gösteren program
using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı giriniz");
            double number = Convert.ToDouble(Console.ReadLine());
            
            if (number < 0)
            {
                Console.WriteLine($"Girdiğiniz {number} sayısı negatiftir");
            }
            else if (number > 0)
            {
                Console.WriteLine($"Girdiğiniz {number} sayısı pozitiftir");
            }
            else
            {
                Console.WriteLine("Girdiğiniz sayı sıfırdır");
            }
        }
    }
}