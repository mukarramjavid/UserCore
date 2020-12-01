using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BussinessOperation.Interfaces;
using demo_master.Models;
using Inferastructure.DataModels;
using Inferastructure.Mails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using UserLive.Models;
using Vonage.Messaging;
using Vonage.Request;


namespace UserLive.Controllers
{
    public class NewUserController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IBOUsers _IBOUsers;
        private readonly IBOCountry _IBOCountry;
        private readonly IHostingEnvironment _HostEnvironment;
        private readonly MailSend _mail;
        static int _PageNumber = 1;
        private IMemoryCache _cache;


        public NewUserController(IBOUsers IBOUsers, IBOCountry IBOCountry, IHostingEnvironment HostEnvironment, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _IBOUsers = IBOUsers;
            _IBOCountry = IBOCountry;
            _HostEnvironment = HostEnvironment;
            _config = configuration;
            _cache = memoryCache;
            _mail = new MailSend(_HostEnvironment, _config);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewUsersList()
        {
            return View();
        }
        public IActionResult GetUsersOnScroll()
        {
            string cacheName = "userslist" + DateTime.Now.Date;
            var list = _cache.Get<List<UserModel>>(cacheName);
            _PageNumber = 1;
            return View();
        }
        public ActionResult InsertMaster()
        {

            return View();
        }
        [HttpPost]
        public ActionResult InsertMasterData(NewUserVM data)
        {
            var dataResult = JsonConvert.DeserializeObject<List<NewUserVM>>(data.dataList);

            foreach (var item in dataResult)
            {
                var user = new UserModel
                {
                    userEmail = item.userEmail,
                    userName = item.userName,
                    userPhone = item.userPhone,
                    userPwd = item.userPwd,
                    countryId = item.userCountry,
                    skillIds = item.uskillIds

                };
                SendMail(user.userEmail, user.userPwd);
                //SendSMS(user.userPhone,user.userName);
                _IBOUsers.InsertMaster(user);
            }


            return RedirectToAction("InsertMaster");
        }

        public JsonResult GetMasterUsersListsOnScroll()
        {
            List<NewUserVM> objList = new List<NewUserVM>();
            List<UserModel> userModelList = new List<UserModel>();
            string cacheName = "users-matches-" + DateTime.Now.Date.ToString("MM-dd-yyyy") + "-";
            if (!_cache.TryGetValue(cacheName, out userModelList))
            {

                if (userModelList == null)
                {
                    userModelList = _IBOUsers.GetMasterUsers();
                }

                // cache memory
                if (userModelList != null && userModelList.Count > 0)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(5));
                    // Save data in cache.
                    _cache.Set(cacheName, userModelList, cacheEntryOptions);
                }

            }
            userModelList.ForEach(item =>
            {
                NewUserVM uvm = new NewUserVM
                {
                    userName = item.userName,
                    userEmail = item.userEmail,
                    userPhone = item.userPhone,
                    userPwd = item.userPwd,
                    userId = item.userId,
                    countryName = item.countryName,
                    provinceName = item.provinceName,
                    IsVerified = item.IsVerified
                };
                objList.Add(uvm);
            });
            objList = objList.Skip((_PageNumber - 1) * 10).Take(10).ToList();
            _PageNumber++;

            //if (objList == null)
            //{
            //    _PageNumber = 1;

            //}
            //var obj = objList;
            return Json(objList, new JsonSerializerSettings());
        }
        public JsonResult GetMasterUsersLists()
        {
            //var sa = new JsonSerializerSettings();
            var list = _IBOUsers.GetMasterUsers();
            List<NewUserVM> objList = new List<NewUserVM>();
            foreach (var item in list)
            {
                NewUserVM uvm = new NewUserVM
                {
                    userName = item.userName,
                    userEmail = item.userEmail,
                    userPhone = item.userPhone,
                    userPwd = item.userPwd,
                    userId = item.userId,
                    countryName = item.countryName,
                    provinceName = item.provinceName,
                    IsVerified = item.IsVerified
                };

                objList.Add(uvm);


            }

            //var obj = objList;
            return Json(objList, new JsonSerializerSettings());
        }

        public JsonResult DeleteRecordbyID(int id)
        {
            _IBOUsers.DeleteMasterRecord(id);
            return Json(new JsonSerializerSettings());
        }


        public JsonResult GetMasterbyId(int id)
        {
            var countryList = _IBOCountry.GetCountryLists();
            var provinceList = _IBOCountry.GetProvinceLists();
            var rcrd = _IBOUsers.GetMasterById(id);

            var uvm = new NewUserVM()
            {
                userId = rcrd.userId,
                userName = rcrd.userName,
                userEmail = rcrd.userEmail,
                userPwd = rcrd.userPwd,
                userPhone = rcrd.userPhone,
                userCountry = rcrd.countryId,
                countryName = (from name in countryList
                               where name.countryId == rcrd.countryId
                               select name.countryName
                                ).FirstOrDefault(),
                uskillIds = rcrd.skillIds,




            };
            return Json(uvm, new JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult GetMasterbyId(int id, NewUserVM uvm)
        {
            var user = new UserModel()
            {
                userId = id,
                userEmail = uvm.userEmail,
                userName = uvm.userName,
                userPhone = uvm.userPhone,
                userPwd = uvm.userPwd,
                countryId = uvm.userCountry
            };
            int rcrd = _IBOUsers.UpdateMasterUser(id, user);

            return Json(new JsonSerializerSettings());
        }

        private void SendMail(string email, string pwd)
        {
            var hostName = _config.GetSection("MailSending").GetSection("smptHost").Value;
            var hostPwd = _config.GetSection("MailSending").GetSection("smptPwd").Value;
            var serverName = _config.GetSection("MailSending").GetSection("smptServer").Value;
            var CC = _config.GetSection("MailSending").GetSection("CC").Value;
            var UseDefaultCredentials = Convert.ToBoolean(_config.GetSection("MailSending").GetSection("UseDefaultCredentials").Value);
            var EnableSsl = Convert.ToBoolean(_config.GetSection("MailSending").GetSection("EnableSsl").Value);
            var portNumber = Convert.ToInt32(_config.GetSection("MailSending").GetSection("Port").Value);


            try
            {
                SmtpClient client = new SmtpClient(serverName)
                {
                    Credentials = new NetworkCredential(hostName, hostPwd),
                    UseDefaultCredentials = UseDefaultCredentials,
                    EnableSsl = EnableSsl,
                    Port = portNumber
                };


                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = "**Account Registration**";
                mailMessage.To.Add(email);
                mailMessage.From = new MailAddress(hostName);
                mailMessage.Body = CreateBody(email, pwd);
                mailMessage.IsBodyHtml = true;
                mailMessage.CC.Add(CC);


                client.Send(mailMessage);

            }
            catch (Exception ex)
            {
                var exec = ex.Message;
            }
        }
        private string CreateBody(string email, string pwd)
        {
            string path = "Views/Account.html";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_HostEnvironment.ContentRootPath, path)))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{email}", email);
            body = body.Replace("{pwd}", pwd);

            return body;
        }
        public void SendSMS(string phone, string name)
        {
            string text = $"Hello {name} !! Welcome !!";
            try
            {
                var VONAGE_API_KEY = (_config.GetSection("SecondPkg").GetSection("VONAGE_API_KEY").Value);
                var VONAGE_API_SECRET = (_config.GetSection("SecondPkg").GetSection("VONAGE_API_SECRET").Value);
                var FROM = (_config.GetSection("SecondPkg").GetSection("FROM_NUMBER").Value);
                var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
                var client = new SmsClient(credentials);
                var request = new SendSmsRequest { To = phone, From = FROM, Text = text };
                var response = client.SendAnSms(request);
            }
            catch (VonageSmsResponseException ex)
            {
                ViewBag.Error = ex.Message;
            }
            //Sid = (_config.GetSection("SMSSending").GetSection("Account_Sid").Value);
            //token = (_config.GetSection("SMSSending").GetSection("Auth_Token").Value);
            //phoneNo = (_config.GetSection("SMSSending").GetSection("PHONE").Value);
            //try
            //{
            //    // Find your Account Sid and Auth Token at twilio.com/user/account  

            //    TwilioClient.Init(Sid,token);

            //    var to = new PhoneNumber("+92" + phone);
            //    var message = MessageResource.Create(
            //        to,
            //        from: new PhoneNumber(phoneNo), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).  
            //        body: $"Hello {name} !! Welcome !!");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($" Registration Failure : {ex.Message} ");
            //}
        }


    }
}
