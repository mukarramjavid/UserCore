﻿using demo_master.Models;
using Inferastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessOperation.Interfaces
{
    public interface IBOUsers
    {
        List<Users> GetUsers();

        //Create User Interafce Services
        int CreateUser(Users user);

        Users GetById(int id);
        int UpdateUser(int id, Users user);
        void DeleteRecord(int id);
        int SaveAddress(UserAddress userAd);
        UserAddress GetAddressById(int id);
        int UpdateAddress(int rcrd, UserAddress objAd);
        void DeleteAddress(int id);
        int Register();
        void InsertMaster(UserModel user);
        List<UserModel> GetMasterUsers();
        void DeleteMasterRecord(int id);
        UserModel GetMasterById(int id);
        int UpdateMasterUser(int id, UserModel user);
    }
}
