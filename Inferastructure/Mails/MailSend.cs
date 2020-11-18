using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Inferastructure.Mails
{
    public class MailSend
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _HostEnvironment;
        public MailSend(IHostingEnvironment HostEnvironment, IConfiguration configuration)
        {
            _HostEnvironment = HostEnvironment;
            _config = configuration;
        }
        public void SendMail(string email, string pwd)
        {
            var hostName = _config.GetSection("MailSending").GetSection("smptHost").Value;
            var _hostName = _config["MailSending:smptHost"];
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
    }
}
