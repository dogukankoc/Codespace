﻿using SiteManagement.Helpers;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using System.Linq;  

namespace SiteManagement.Services
{
    public static class AuthServices
    {
        public static string Register(User user)
        {
            using(SiteManagementDbContext context = new SiteManagementDbContext())
            {
                var userControl = context.Users.Any(u => u.Email == user.Email);
                if (userControl)
                {
                    string availableMail = "Böyle bir Email sistemde mevcuttur, lütfen farklı bir Email giriniz.";
                    return availableMail;
                }
                else
                {
                    string password = user.Password.ToString();
                    user.Password = EncryptHelper.SHA256Hash(password);
                    user.PasswordConfirmation = user.Password;
                    context.Add(user);
                    context.SaveChanges();
                    return null;
                }
            }
        }
        public static string Login(string email, string password)
        {
            using (var context = new SiteManagementDbContext())
            {
                var userControl = context.Users.FirstOrDefault(x => x.Email == email);
                password = EncryptHelper.SHA256Hash(password);

                if (userControl !=null && userControl.Password == password)
                {
                    string welcomeMessage = $"{userControl.NameSurname}";
                    return welcomeMessage;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
