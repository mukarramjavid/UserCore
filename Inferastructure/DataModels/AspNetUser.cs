using System;
using System.Collections.Generic;
using System.Text;

namespace Inferastructure.DataModels
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
