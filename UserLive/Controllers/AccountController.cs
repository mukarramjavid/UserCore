using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessOperation.Interfaces;
using Inferastructure.DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserLive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IBOUsers _IBOUsers;
        private readonly IHostingEnvironment _HostEnvironment;
        public AccountController(IBOUsers IBOUsers, IHostingEnvironment HostEnvironment)
        {
            _IBOUsers = IBOUsers;
            _HostEnvironment = HostEnvironment;
        }
        [HttpPost]
        public int Register(AspNetUser aspNetUser)
        {
            var reg = _IBOUsers.Register();
            return reg;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
