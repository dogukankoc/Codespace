//Klavyeden girilen bir sayının seçime bağlı olarak karesini, küpünü ya da kare kökünü alan program
using System;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bir sayı giriniz");
            double number = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nSayının Karesini almak istiyorsanız 1'e \nSayının küpünü almak istiyorsanız 2'ye \nSayının karakökünü almak istiyorsanız 3'e \nbasınız.\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine($"{number}'nın karesi = {number * number}");
            }

            else if (choice == 2)
            {
                Console.WriteLine($"{number}'ın küpü = {number * number * number}"); 
            }
            
            else if (choice == 3)
            {
                Console.WriteLine($"{number}'ın karekökü = {Math.Sqrt(number)}");
            }
            
            else
            {
                Console.WriteLine("Yanlış seçim yaptınız");
            } 
        }
    }
}


