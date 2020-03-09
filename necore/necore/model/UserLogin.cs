using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace necore.model
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Otp { get; set; }
    }
}
