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


        public NewUserController(IBOUsers IBOUsers, IBOCountry IBOCountry, IHostingEnvironment HostEnvironment, IConfiguration configuration)
        {
            _IBOUsers = IBOUsers;
            _IBOCountry = IBOCountry;
            _HostEnvironment = HostEnvironment;
            _config = configuration;
            _mail = new MailSend(_HostEnvironment,_config);
        }
        public IActionResult Index()
        {
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
                    userEmail = item._userEmail,
                    userName = item._userName,
                    userPhone = item._userPhone,
                    userPwd = item._userPwd,
                    countryId = item._userCountry,
                    skillIds = item._uskillIds

                };
                SendMail(user.userEmail, user.userPwd);
                //SendSMS(user.userPhone,user.userName);
                _IBOUsers.InsertMaster(user);
            }


            return RedirectToAction("InsertMaster");
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
                    _userName = item.userName,
                    _userEmail = item.userEmail,
                    _userPhone = item.userPhone,
                    _userPwd = item.userPwd,
                    _userId = item.userId,
                    _countryName = item.countryName,
                    _provinceName = item.provinceName

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
                _userId = rcrd.userId,
                _userName = rcrd.userName,
                _userEmail = rcrd.userEmail,
                _userPwd = rcrd.userPwd,
                _userPhone = rcrd.userPhone,
                _userCountry = rcrd.countryId,
                _countryName = (from name in countryList
                                where name.countryId == rcrd.countryId
                                select name.countryName
                                ).FirstOrDefault(),
                _uskillIds = rcrd.skillIds,
               



            };
            return Json(uvm, new JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult GetMasterbyId(int id, NewUserVM uvm)
        {
            var user = new UserModel()
            {
                userId = id,
                userEmail = uvm._userEmail,
                userName = uvm._userName,
                userPhone = uvm._userPhone,
                userPwd = uvm._userPwd,
                countryId = uvm._userCountry
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
        public void SendSMS(string phone,string name)
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

