using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inferastructure.DataModels
{
    public class UserAddress
    {
        public int address_id { set; get; }
        public string city_name { set; get; }
        public int userID { set; get; }
    }
}
