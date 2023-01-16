// Kullanıcıdan 2 tane sayı istenerek 1. sayının 2.sayıya tam bölünmesi durumunda "Tam Bölünüyor" yazan, aksi durumda tam bölünmüyor diyerek kalanı ekranda gösteren örnek 
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1, number2;

            Console.WriteLine("1. Sayıyı Girin");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("2. Sayıyı Girin");
            number2 = Convert.ToInt32(Console.ReadLine());

            if (number1 % number2 == 0)
            {
                Console.WriteLine("Tam bölünüyor");
            }
            else
            {
                Console.WriteLine("Tam Bölünmüyor");
            }
        }
    }
}

