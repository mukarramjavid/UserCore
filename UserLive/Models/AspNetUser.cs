using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Models
{
    public class AspNetUser
    {
        public string ID { set; get; }
        public string UserName { set; get; }
        public string NormalizedUserName { set; get; }
        public string Email { set; get; }
        public string NormalizedEmail { set; get; }
        public string PhoneNumber { set; get; }
    }
}
