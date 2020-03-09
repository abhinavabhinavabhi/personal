using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace necore.model
{
    public class userlog
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int otp{ get; set; }
    }
}
