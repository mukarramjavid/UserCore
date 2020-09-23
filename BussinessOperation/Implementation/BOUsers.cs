using BussinessOperation.Interfaces;
using Inferastructure.DataModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessOperation.Implementation
{
    public class BOUsers : IBOUsers
    {
        private readonly IUserService _userService;
        public BOUsers(IUserService userService)
        {
            _userService = userService;
        }

        //BussinessOperation create Implementation
        public int CreateUser(Users user)
        {
            //go to User Interafce Services
            int id = 0;
            id = _userService.CreateUser(user);
            return id;
        }

        public void DeleteAddress(int id)
        {
            _userService.DeleteAddress(id);
        }

        public void DeleteRecord(int id)
        {
            _userService.DeleteRecord(id);
        }

        public UserAddress GetAddressById(int id)
        {
            return _userService.GetAddressById(id);
        }

        public Users GetById(int id)
        {
            Users user = null;
            user= _userService.GetById(id);
            return user;
        }

        public List<Users> GetUsers()
        {
            List<Users> objUserList = new List<Users>();
            objUserList=_userService.GetUsers();
            return objUserList;
        }

        public int SaveAddress(UserAddress userAd)
        {
            return _userService.SaveAddress(userAd);
        }

        public int UpdateAddress(int rcrd, UserAddress objAd)
        {
            return _userService.UpdateAddress(rcrd, objAd);
        }

        public int UpdateUser(int id, Users user)
        {
            int local_id = 0;
            local_id = _userService.UpdateUser(id,user);
            return local_id;
        }
    }
}
