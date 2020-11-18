using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BussinessOperation.Interfaces;
using Inferastructure.DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Logging;
using UserLive.Models;
using Wangkanai.Detection;

namespace UserLive.Controllers
{
    public class HomeController : Controller
    {
        public static string imgURL = "";
        private readonly IBOUsers _IBOUsers;
        private readonly IHostingEnvironment _HostEnvironment;
        private readonly IDetection _detection;
        private readonly IActionContextAccessor _accessor;
        private readonly ILogger _logger;

        public HomeController(IBOUsers IBOUsers, IHostingEnvironment HostEnvironment, IDetection detection, IActionContextAccessor accessor, ILogger<HomeController> logger)
        {
            _IBOUsers = IBOUsers;
            _HostEnvironment = HostEnvironment;
            _detection = detection;
            _accessor = accessor;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
            
                var browser = _detection.Browser.Type.ToString();
                var decive = _detection.Device.Type.ToString();
                var crawlerType = _detection.UserAgent.ToString();
                var ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
                var dem = _accessor.ActionContext.HttpContext.Connection.RemotePort.ToString();
            }
            catch (Exception ex)
            {
                var exe = ex.Message;
               
            }
            return View();
        }

        public IActionResult About()
        {
            _logger.LogInformation("In About in Index Action");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UsersList()
        {
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
                uvm.cityName = item.city_name;

                objList.Add(uvm);


            }
            return View(objList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            UserViewModel uvm = new UserViewModel();
            if (uvm.ImagePathUvm == null)
            {
                uvm.ImagePathUvm = "~/images/img/programmer.gif";
            }
            return View(uvm);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel uvm)
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
                return RedirectToAction("Register", "Admin");
            }
            else
            {
                TempData["IsSuccess"] = "Inserted Successfully";
                return RedirectToAction("Create");
            }

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

        public IActionResult GetById(int id)
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

            return View(uvm);
        }
        [HttpPost]
        public IActionResult GetById(int id, UserViewModel uvm)
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
            return RedirectToAction("UsersList");
        }

        public IActionResult DeleteRecord(int id)
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

            return RedirectToAction("UsersList");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
