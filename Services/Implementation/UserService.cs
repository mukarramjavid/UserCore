using demo_master.Models;
using Inferastructure.DataModels;
using Repository.Interfaces;
using Repository.Providers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userRepository.UnitOfWork = unitOfWork;

        }
        public List<Users> GetUsers()
        {
            List<Users> objList = new List<Users>();
            _unitOfWork.Open();

            objList = _userRepository.GetUsers();

            _unitOfWork.Close();
            return objList;
        }
        public void Dispose()
        {
            Disposing(true);
        }
        protected void Disposing(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Close();
            }
        }

        public int CreateUser(Users user)
        {
            int id = 0;
            
            _unitOfWork.Open();
            id = _userRepository.Create(user);
            _unitOfWork.Close();
            return id;
        }

        public Users GetById(int id)
        {
            _unitOfWork.Open();
            Users obj = _userRepository.GetMasterById(id);
            _unitOfWork.Close();
            return obj;
        }

        public int UpdateUser(int id,Users user)
        {
            int local_id = 0;

            _unitOfWork.Open();
            local_id = _userRepository.UpdateUser(id,user);
            _unitOfWork.Close();
            return local_id;
        }

        public void DeleteRecord(int id)
        {
            _unitOfWork.Open();
            _userRepository.DeleteRecord(id);
            _unitOfWork.Close();
        }

        public int SaveAddress(UserAddress userAd)
        {
            _unitOfWork.Open();
            int addressId= _userRepository.SaveAddress(userAd);
            _unitOfWork.Close();
            return addressId;
        }

        public UserAddress GetAddressById(int id)
        {
            _unitOfWork.Open();
            UserAddress objAd = _userRepository.GetAddressById(id);
            _unitOfWork.Close();
            return objAd;

        }

        public int UpdateAddress(int rcrd, UserAddress objAd)
        {
            int local_id = 0;
            _unitOfWork.Open();
            local_id = _userRepository.UpdateAddress(rcrd, objAd);
            _unitOfWork.Close();
            return local_id;
        }

        public void DeleteAddress(int id)
        {
            _unitOfWork.Open();
            _userRepository.DeleteAddress(id);
            _unitOfWork.Close();
        }

        public void InsertMaster(UserModel user)
        {
            _unitOfWork.Open();
            _userRepository.InsertMaster(user);
            _unitOfWork.Close();
        }

        public List<UserModel> GetMasterUsers()
        {
            List<UserModel> objList = new List<UserModel>();
            _unitOfWork.Open();

            objList = _userRepository.GetMasterUsers();

            _unitOfWork.Close();
            return objList;
            
        }

        public void DeleteMasterRecord(int id)
        {
            _unitOfWork.Open();
            _userRepository.DeleteMasterRecord(id);
            _unitOfWork.Close();
        }

        public UserModel GetMasterById(int id)
        {
            _unitOfWork.Open();
            UserModel obj = _userRepository.GetUserMasterById(id);
            //UserModel obj = _userRepository.GetMasterById(id);
            _unitOfWork.Close();
            return obj;
        }

        public int UpdateMasterUser(int id, UserModel user)
        {
            int local_id = 0;

            _unitOfWork.Open();
            local_id = _userRepository.UpdateMasterUser(id, user);
            _unitOfWork.Close();
            return local_id;
        }

        public void AddDate(DateTime date)
        {
            _unitOfWork.Open();
             _userRepository.AddDate(date);
            _unitOfWork.Close();
        }
    }
}
