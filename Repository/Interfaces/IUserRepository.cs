using demo_master.Models;
using Inferastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRepository: IBaseRepository
    {
        List<Users> GetUsers();

        int Create(Users user);

        Users GetMasterById(int id);
        int UpdateUser(int id, Users user);
        void DeleteRecord(int id);
        int SaveAddress(UserAddress userAd);
        UserAddress GetAddressById(int id);
        int UpdateAddress(int rcrd, UserAddress objAd);
        void DeleteAddress(int id);
        void InsertMaster(UserModel user);
        List<UserModel> GetMasterUsers();
        void DeleteMasterRecord(int id);
        UserModel GetUserMasterById(int id);
        int UpdateMasterUser(int id, UserModel user);
        void AddDate(DateTime date);
    }
}
