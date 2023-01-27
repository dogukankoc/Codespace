// Kullanıcı adı  "dogukankoc" ve şifresi "1234" olan kullanıcının, kulanıcı adı ve şifresini girmesi istenecek, eğer doğru ise hoşgeldin kullanıcı yazacak, kullanıcı adı veya şifresi yanlış ise "kullanıcı adı veya şifreniz yanlıştır" uyarısı verecektir
using System;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kullanıcı Adı : ");
            string username = Console.ReadLine();
            Console.Write("Şifreniz: ");
            string password = Console.ReadLine();

            if (username == "dogukankoc" && password == "1234")
            {
                Console.WriteLine($"Hoşgeldin {username}");
            }
            else
            {
                Console.WriteLine("Kullanıcı adı veya şifreniz yanlıştır");

            }
        }
    }
}
