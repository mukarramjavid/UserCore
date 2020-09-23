using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Models
{
    public class UserViewModel
    {
        public int user_id { get; set; }

        [Required]
        [Display(Name ="Username")]
        public string user_name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string user_email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(6,ErrorMessage ="only 6 characters are allowed.")]
        public string user_pwd { get; set; }

        [Display(Name = "Phone")]
        //[StringLength(11, ErrorMessage = "only 11 characters are allowed.")]
        public int user_phone { get; set; }

        [Display(Name = "Age")]
        public int user_age { get; set; }



        [Display(Name = "AddresID")]
        public int addID {set; get; }

        [Display(Name = "City")]
        public string cityName { set; get; }

        public string ImagePathUvm { get; set; }
        public IFormFile CoverPic { get; set; }
    }

    //public class UserAddressViewModel
    //{
    //    public int address_id { set; get; }


    //    public int userID { set; get; }
    //}
}
