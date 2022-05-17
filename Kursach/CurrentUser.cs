using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    internal class CurrentUser
    {
        public string Login { get; set; }
        public string Role { get; set; }

        public CurrentUser(string login, string role)
        {
            Login = login;
            Role = role;
        }

        public CurrentUser()
        {
        }
    }
}
