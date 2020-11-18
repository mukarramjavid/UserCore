using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessOperation.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using UserLive.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserLive.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IBOUsers _iBOUsers;
        private readonly IHostingEnvironment _hostEnvironment;

        public UsersController(IBOUsers IBOUsers, IHostingEnvironment HostEnvironment)
        {
            _iBOUsers = IBOUsers;
            _hostEnvironment = HostEnvironment;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {

            var list = _iBOUsers.GetUsers();
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
            return objList;
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
