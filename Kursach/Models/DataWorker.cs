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
                    var currUser = bd.Logins.Where(u => u.Name == name).First();
                    currUser.LastEnter = DateTime.Now;
                    bd.SaveChanges();
                        return true;
                    }
                    else return false;
            }

        }
        public static bool CheckUser(string name, string password,string? Num)
        {
            using (var bd = new SAYKOV_PDDContext())
            {
                try
                {

                    PasswordVerificationResult ver = passwordHasher.VerifyHashedPassword(bd.Logins.Where(u => u.Name == name || u.Phone == Num).First().Password, password);
                    if (ver == PasswordVerificationResult.Success)
                    {
                        CurrentUser.setInstance(bd.Logins.Where(u => u.Name == name).First());
                        return true;
                    }
                    else return false;
                }

                catch (Exception ex) {
                    return false; }
            }
        }
        public static bool AddUser(string NameUser, string PasswordUser, string? Num, string UserName, string UserSurname)
        {
            try
            {

                if (!CheckUser(NameUser, PasswordUser, Num))
                    using (var bd = new SAYKOV_PDDContext())
                    {

                        string pass = passwordHasher.HashPassword(PasswordUser);
                        bd.Logins.Add(new Login { Name = NameUser, Password = pass, Phone = Num, IsAdmin = false, UserName = UserName, UserSurname = UserSurname, RegDate = DateTime.Now });
                        bd.SaveChanges();
                        return true;
                    }
                else

                    return false;
            }
            catch (Exception ex) {
                return false;
            }


}
        public static void AddResult(int RightAnswersCount, int WrongAnswersCount, int ticketId)
        {
            if (WrongAnswersCount > 1) 
            {
                using (var bd = new SAYKOV_PDDContext())
                {
                    bd.TicketResults.Add(new TicketResult { UserId = CurrentUser.getInstance().UserId, TicketResult1 = "Тест был завершён досрочно, так как вы допустили 2 ошибки.", ResDate = DateTime.Now, TicketId = ticketId, isPassed = false });
                    bd.SaveChanges();
                } 
            }
            else
            {
                using (var bd = new SAYKOV_PDDContext())
                {
                    bd.TicketResults.Add(new TicketResult { UserId = CurrentUser.getInstance().UserId, TicketResult1 = "Правильные ответы: " + RightAnswersCount + ". Неправильные ответы: " + WrongAnswersCount + '.', ResDate = DateTime.Now , TicketId = ticketId, isPassed = true});
                    bd.SaveChanges();
                }
            }

        }
    }
}
