using Kursach.Models.Base;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    public static class DataWorker
    {

        private static IPasswordHasher passwordHasher = new PasswordHasher();

        public static bool GetUser(string name, string password)
        {


            using (var bd = new SAYKOV_PDDContext())
            {

                    PasswordVerificationResult ver = passwordHasher.VerifyHashedPassword(bd.Logins.Where(u => u.Name == name).First().Password, password);
                    if (ver == PasswordVerificationResult.Success)
                    {
                        CurrentUser.setInstance(bd.Logins.Where(u => u.Name == name).First());
                        return true;
                    }
                    else return false;
            }

        }
        public static bool CheckUser(string name, string password,string? Num)
        {
            using (var bd = new SAYKOV_PDDContext())
            {
                PasswordVerificationResult ver = passwordHasher.VerifyHashedPassword(bd.Logins.Where(u => u.Name == name || u.Phone == Num).FirstOrDefault().Password, password);
                if (ver == PasswordVerificationResult.Success)
                {
                    CurrentUser.setInstance(bd.Logins.Where(u => u.Name == name).First());
                    return true;
                }
                else
                    return false;
            }
        }
        public static bool AddUser(string NameUser, string PasswordUser, string? Num)
        {

            if (!CheckUser(NameUser, PasswordUser, Num))
                using (var bd = new SAYKOV_PDDContext())
                {

                    string pass = passwordHasher.HashPassword(PasswordUser);
                    bd.Logins.Add(new Login { Name = NameUser, Password = pass, Phone = Num, IsAdmin = false });
                    bd.SaveChanges();
                    return true;
                }
            else
                    return false;
            
        }
    }
}
