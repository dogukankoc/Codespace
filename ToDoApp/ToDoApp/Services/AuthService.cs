using ToDoApp.Db;
using ToDoApp.Db.Entities;
using ToDoApp.Helpers;

namespace ToDoApp.Services
{
    public static class AuthService
    {
        public static User Register()
        {
            Console.WriteLine("\nUygulamaya kayıt olmaya karar vermene çok sevindim, hadi seni kayıt edelim ...");
            while (true)
            {
                Console.Write("Ad ve Soyad: ");
                string nameSurname = Console.ReadLine() ?? string.Empty;
                nameSurname = nameSurname.Trim();
                if (string.IsNullOrWhiteSpace(nameSurname))
                {
                    Console.WriteLine("Ad ve Soyad kısmı boş bırakılamaz");
                    continue;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Kullanıcı Adı: ");
                        var userName = Console.ReadLine();
                        userName = userName.Trim();
                        using (ToDoContext context = new ToDoContext())
                        {
                            var userControl = context.Users.Any(u => u.UserName == userName);

                            if (userControl)
                            {
                                Console.WriteLine($"\n{userName} kullanıcı adı mevcuttur lütfen farklı bir kullanıcı adı giriniz");
                                continue;
                            }
                            else
                            {
                                Console.Write("Şifre: ");
                                string password = Console.ReadLine() ?? string.Empty;
                            CHECKEMAIL:
                                Console.Write("E-Mail: ");
                                string eMail = Console.ReadLine() ?? string.Empty;
                                var checkedEmail = RegexHelper.CheckEmailRegex(eMail);
                                if (checkedEmail)
                                {
                                    User user = new User()
                                    {
                                        NameSurname = nameSurname,
                                        UserName = userName,
                                        Password = EncryptHelper.SHA1Encrypt(password),
                                        Email = eMail,
                                    };
                                    context.Add(user);
                                    context.SaveChanges();
                                    return user;
                                }
                                else
                                {
                                    goto CHECKEMAIL;
                                }
                            }
                            break;
                        }
                    }
                }
                break;
            }
        }

        public static User Login()
        {
            Console.WriteLine("\nGiriş yapmak için lütfen Kullanıcı Adını ve Şifreni gir\n");

        WRONGLOGİN:
            Console.Write("Kullanıcı Adı: ");
            var userName = Console.ReadLine() ?? string.Empty;
            Console.Write("Şifre: ");
            var password = Console.ReadLine() ?? string.Empty;

            using (ToDoContext context = new())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == EncryptHelper.SHA1Encrypt(password));
                if (user != null)
                {
                    return user;
                }
                else
                {
                    Console.WriteLine("Hatali giriş, tekrar deneyiniz\n");
                    goto WRONGLOGİN;
                }
            }
        }

        public static User MainScreen()
        {
            try
            {
            WRONGCHOISE:
                Console.Write("ToDoApp'e Hoş geldin..\n\nGiriş yapmak için:1 - Kayıt olmak için:2 >>> ");
                try
                {
                    var loginOrRegister = Convert.ToInt32(Console.ReadLine());
                    switch (loginOrRegister)
                    {
                        case 1:
                            return AuthService.Login();
                            break;

                        case 2:
                            return AuthService.Register();
                            break;
                        default:
                            goto WRONGCHOISE;
                    }
                }
                catch (Exception)
                {
                    goto WRONGCHOISE;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
