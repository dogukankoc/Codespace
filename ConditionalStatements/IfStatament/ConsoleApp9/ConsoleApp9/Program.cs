//Bir kişi mağazasında 100 TL ve üzeri alışveriş yaparsa %10 indirim, 200 TL ve üzeri alışveriş yaparsa %15 indirim, 300 TL ve alışveriş yaparsa %20 indirim kazandığını ve ödeyeceği miktarı ekrana yazdıran kod.

using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price;
            Console.Write("Mağazadan kaç TL'lik alışveriş yaptığınızı yazın: ");
            price = Convert.ToDouble(Console.ReadLine());

            if (price >= 100 && price < 200)
            {
                double earning = (price * 10) / 100;
                double netPrice = price - earning;
                Console.WriteLine($"100 TL ve üzeri alışveriş yaptığınız için %10 indirim kazandınız ve ödeyeceğiniz miktar = {netPrice} TL'dir");
            }

            else if (price >= 200 && price < 300)
            {
                double earning = (price * 15) / 100;
                double netPrice = price - earning;
                Console.WriteLine($"200 TL ve üzeri alışveriş yaptığınız için %15 indirim kazandınız ve ödeyeceğiniz miktar = {netPrice}");

            }

            else if (price >= 300)
            {
                double earning = (price * 20) / 100;
                double netPrice = price - earning;
                Console.WriteLine($"300 TL ve üzeri alışveriş yaptığınız için %20 indirim kazandınız ve ödeyeceğiniz miktar = {netPrice}");

            }

            else if (price >= 0 && price < 100)
            {
                Console.WriteLine("İndirim kazanmadınız");
            }

            else
            {
                Console.WriteLine("Hatalı bir girişi yaptınız");
            }
        }
    }
}
