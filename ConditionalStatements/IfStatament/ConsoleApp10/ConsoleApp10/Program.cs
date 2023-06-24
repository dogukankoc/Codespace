 //Girilen sayı hem 2 ile hem de 3 ile tam bölünebiliyorsa "2 ve 3 ün katı", sadece 2 ile bölünebiliyorsa "2'nin katı", sadece 3 ile bölünebiliyorsa "3'ün katı", ne 2 'ye ne de 3'e bölünmüyorsa "2 veye 3'ün katı değil" mesajı veren console uygulaması
using System;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int number;
                Console.WriteLine("Bir tam sayı giriniz");
                number = Convert.ToInt32(Console.ReadLine());

                if (number % 3 == 0 && number % 2 == 0)
                    Console.WriteLine($"{number} sayısı, 2 ve 3 ile tam bölünebilmektedir");
                else if (number % 2 == 0)
                    Console.WriteLine($"{number} sayısı, 2 ile tam bölünebilmektedir.");
                else if (number % 3 == 0)
                    Console.WriteLine($"{number} sayısı, 3 ile tam bölünebilmektedir");
                else
                    Console.WriteLine($"{number} sayısı, 2 ve 3'ün katı değildir");
            }
        }
    }
}
