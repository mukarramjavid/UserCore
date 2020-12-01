
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_master.Models
{
    public class UserModel
    {
        //user
        public int userId { set; get; }
        public string userName { set; get; }
        public string userEmail { set; get; }
        public string userPwd { set; get; }
        public string userPhone { set; get; }
        public bool IsVerified { set; get; }

        //Country
        public int countryId { set; get; }
        public string countryName { set; get; }

        //Province
        public int provinceId { set; get; }
        public string provinceName { set; get; }

        //skills
        public string skillIds { set; get; }
        public string skillName { set; get; }


    }
}
