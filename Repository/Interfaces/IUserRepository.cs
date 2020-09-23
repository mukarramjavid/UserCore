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

        Users GetbyId(int id);
        int UpdateUser(int id, Users user);
        void DeleteRecord(int id);
        int SaveAddress(UserAddress userAd);
        UserAddress GetAddressById(int id);
        int UpdateAddress(int rcrd, UserAddress objAd);
        void DeleteAddress(int id);
    }
}
