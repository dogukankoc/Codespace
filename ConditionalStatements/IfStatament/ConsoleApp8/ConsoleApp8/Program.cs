//Öğrencinin 3 sınav notu alınacak ve not ortalaması 50 ve üzeri ise "Geçti" 50'nin altındaysa "Kaldı" yazacak.
using System;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double scoreA, scoreB, scoreC;

            Console.WriteLine("Merhaba Üniversiteli sırasıyla 3 sınav notunu girer misin?");
            Console.Write("1.Not: ");
            scoreA = Convert.ToDouble(Console.ReadLine());
            Console.Write("2.Not: ");
            scoreB = Convert.ToDouble(Console.ReadLine());
            Console.Write("3.Not: ");
            scoreC = Convert.ToDouble(Console.ReadLine());

            double averageScore = (scoreA + scoreB + scoreC) / 3;
            averageScore = Math.Round(averageScore, 2);

            if (averageScore >= 50 && averageScore <= 100)
            {
                Console.WriteLine($"Tebrikler Geçtin Notun: {averageScore}");
            }
            else if (averageScore < 50 && averageScore >= 0)
            {
                Console.WriteLine($"Üzgünüm kaldın Notun: {averageScore} , seneye daha çok çalışmalısın");
            }
            else
            {
                Console.WriteLine("Geçersiz değer girdin");
            }
        }
    }
}