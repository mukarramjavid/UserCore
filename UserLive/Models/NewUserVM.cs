using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Models
{
    public class NewUserVM
    {
        public int _userId { set; get; }
        public string _userName { set; get; }
        public string _userEmail { set; get; }
        public string _userPwd { set; get; }
        public string _userPhone { set; get; }

        //Country
        public int _userCountry { set; get; }
        public string _countryName { set; get; }

        //Province
        public int _userProvince { set; get; }
        public string _provinceName { set; get; }

        //public int _uskillId { set; get; }
        //public string _uskillName { set; get; }
        public string _uskillIds { set; get; }
        //img
        public string ImagePath { get; set; }
        public IFormFile _cover{ get; set; }
        public string dataList { set; get; }

    }
}
