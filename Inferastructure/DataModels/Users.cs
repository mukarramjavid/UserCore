using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inferastructure.DataModels
{
    public class Users
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_pwd { get; set; }
        public int user_phone { get; set; }
        public int user_age { get; set; }
        public string user_ImagePath { get; set; }

        public int address_id { set; get; }
        public string city_name { set; get; }
        public int userID { set; get; }
    }

    

}
