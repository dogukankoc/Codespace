//Kullanıcıdan suyun sıcaklık değerinin girilmesi istenir. Girilen sıcaklığa göre suyun hangi halde bulunduğunu gösteren örnek
using System;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Suyun sıcaklık değerini giriniz");
            double temperatureValue = Convert.ToDouble(Console.ReadLine());

            if (temperatureValue <= 0)
            {
                Console.WriteLine("Suyun hali katıdır");
            }
            else if (temperatureValue >= 100)
            {
                Console.WriteLine("Suyun hali gazdır");
            }
            else
            {
                Console.WriteLine("Suyun hali sıvıdır");
            }
        }
    }
}

