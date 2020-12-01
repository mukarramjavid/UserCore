using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Models
{
    public class NewUserVM
    {
        public int userId { set; get; }
        public string userName { set; get; }
        public string userEmail { set; get; }
        public string userPwd { set; get; }
        public string userPhone { set; get; }
        public bool IsVerified { set; get; }


        //Country
        public int userCountry { set; get; }
        public string countryName { set; get; }

        //Province
        public int userProvince { set; get; }
        public string provinceName { set; get; }

        //public int _uskillId { set; get; }
        //public string _uskillName { set; get; }
        public string uskillIds { set; get; }
        //img
        public string ImagePath { get; set; }
        public IFormFile _cover{ get; set; }
        public string dataList { set; get; }

    }
}
