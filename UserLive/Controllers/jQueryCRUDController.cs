using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using BussinessOperation.Interfaces;
using Inferastructure.DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserLive.Models;

namespace UserLive.Controllers
{
    public class jQueryCRUDController : Controller
    {
        public static string imgURL = "";
        private readonly IBOUsers _IBOUsers;
        private readonly IHostingEnvironment _HostEnvironment;
        public jQueryCRUDController(IBOUsers IBOUsers, IHostingEnvironment HostEnvironment)
        {
            _IBOUsers = IBOUsers;
            _HostEnvironment = HostEnvironment;
        }
        public ActionResult UsersList()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Create()
        {
            try
            {

            }
            catch (Exception ex)
            {

               
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel uvm)
        {
            try
            {
                string uniqueFileName = UploadedFile(uvm);
                Users user = new Users()
                {
                    user_email = uvm.user_email,
                    user_age = uvm.user_age,
                    user_name = uvm.user_name,
                    user_phone = uvm.user_phone,
                    user_pwd = uvm.user_pwd,
                    user_ImagePath = uniqueFileName
                };
                int id = _IBOUsers.CreateUser(user);
                UserAddress userAd = new UserAddress()
                {
                    city_name = uvm.cityName,
                    userID = id
                };
                int addressId = _IBOUsers.SaveAddress(userAd);
                //controller create action 

                if (id == 0 || addressId == 0)
                {
                    TempData["IsFail"] = "UnSccessfull";
                }
                else
                {
                    TempData["IsSuccess"] = "Inserted Successfully";
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("UsersList");
        }
        public JsonResult GetUsersLists()
        {
            //var sa = new JsonSerializerSettings();
            var list = _IBOUsers.GetUsers();
            List<UserViewModel> objList = new List<UserViewModel>();
            foreach (var item in list)
            {
                UserViewModel uvm = new UserViewModel();
                uvm.user_age = item.user_age;
                uvm.user_id = item.user_id;
                uvm.user_name = item.user_name;
                uvm.user_phone = item.user_phone;
                uvm.user_pwd = item.user_pwd;
                uvm.user_email = item.user_email;
                uvm.ImagePathUvm = item.user_ImagePath;
                uvm.cityName = item.city_name;

                objList.Add(uvm);


            }
            var obj = objList;
            return Json(obj, new JsonSerializerSettings());
        }

        public JsonResult DeleteRecordbyID(int id)
        {
            UserAddress obj = _IBOUsers.GetAddressById(id);

            if (obj == null)
            {
                _IBOUsers.DeleteRecord(id);
            }
            else
            {

                _IBOUsers.DeleteAddress(obj.address_id);
                _IBOUsers.DeleteRecord(id);
            }
            return Json(new JsonSerializerSettings());
        }

        public JsonResult GetbyId(int id)
        {
            var address = _IBOUsers.GetAddressById(id);
            var rcrd = _IBOUsers.GetById(address.userID);
            var uvm = new UserViewModel()
            {
                user_id = rcrd.user_id,
                user_age = rcrd.user_age,
                user_email = rcrd.user_email,
                user_name = rcrd.user_name,
                user_phone = rcrd.user_phone,
                user_pwd = rcrd.user_pwd,
                ImagePathUvm = rcrd.user_ImagePath,
                //CoverPic=rcrd.CoverPic
                cityName = address.city_name,
                addID = address.address_id,

            };
            imgURL = uvm.ImagePathUvm;
            return Json(uvm, new JsonSerializerSettings());
        }
        [HttpPost]
        public JsonResult GetbyId(int id, UserViewModel uvm)
        {
            Users user;
            if (uvm.ImagePathUvm == imgURL)
            {
                user = new Users()
                {
                    user_id = id,
                    user_email = uvm.user_email,
                    user_age = uvm.user_age,
                    user_name = uvm.user_name,
                    user_phone = uvm.user_phone,
                    user_pwd = uvm.user_pwd,
                    user_ImagePath = imgURL

                };
            }
            else if (uvm.ImagePathUvm == null && uvm.CoverPic == null)
            {
                user = new Users()
                {
                    user_id = id,
                    user_email = uvm.user_email,
                    user_age = uvm.user_age,
                    user_name = uvm.user_name,
                    user_phone = uvm.user_phone,
                    user_pwd = uvm.user_pwd,
                    user_ImagePath = null

                };
            }
            else
            {
                string uniqueFileName = UploadedFile(uvm);
                user = new Users()
                {
                    user_id = id,
                    user_email = uvm.user_email,
                    user_age = uvm.user_age,
                    user_name = uvm.user_name,
                    user_phone = uvm.user_phone,
                    user_pwd = uvm.user_pwd,
                    user_ImagePath = uniqueFileName

                };
            }

            int rcrd = _IBOUsers.UpdateUser(id, user);
            UserAddress objAd = new UserAddress()
            {
                address_id = uvm.addID,
                city_name = uvm.cityName,
                userID = rcrd
            };
            int adID = _IBOUsers.UpdateAddress(rcrd, objAd);
            return Json(new JsonSerializerSettings());
        }
        private string UploadedFile(UserViewModel uvm)
        {
            string outputpath = "";
            if (uvm.CoverPic != null)
            {
                string uploadsFolder = "users/localImages/";
                uploadsFolder += Guid.NewGuid().ToString() + "_" + uvm.CoverPic.FileName;
                outputpath = "/" + uploadsFolder;
                string uniqueFileName = Path.Combine(_HostEnvironment.WebRootPath, uploadsFolder);
                uvm.CoverPic.CopyTo(new FileStream(uniqueFileName, FileMode.Create));
            }
            return outputpath;
        }
    }
}
