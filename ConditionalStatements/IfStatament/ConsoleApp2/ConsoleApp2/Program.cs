//Girilen sayı çift ise yarısını tek ise 2 katını alarak ekrana yazdıran program
using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;

            Console.WriteLine("Bir tam sayi giriniz");
            number = Convert.ToInt32(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("Girilen sayı çift olduğu için sayının yarısı = {0} ", number/2);
            }
            else
            {
                Console.WriteLine("Girilen sayı tek olduğu için sayının 2 katı = {0} ", number*2);
            }
        }
    }
}
