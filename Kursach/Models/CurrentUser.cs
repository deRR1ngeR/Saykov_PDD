using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
        public static class CurrentUser
        {
            private static Login instance;
            private static object syncRoot = new Object();


            public static Login getInstance()
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Login();
                    }
                }
                return instance;
            }
            public static void setInstance(Login user)
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = user;
                    }
                }
            }
        }
}
