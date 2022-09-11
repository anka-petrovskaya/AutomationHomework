using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outlook
{
    public static class UserCredentials
    {
        public static User HannaUser => new User()
        {
            Email = "medvedev1463@gmail.com",
            Password = "Sad_0310!"
        };
        public static User HannaUser2 => new User()
        {
            Email = "anka.petrovskaya@outlook.com",
            Password = "Vredina912!"
        };
    }
}