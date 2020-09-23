using Dapper;
using Inferastructure.DataModels;
using Repository.Interfaces;
using Repository.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public int Create(Users user)
        {
            int userID = 0;
            //Users objUser = user;
            try
            {
                const string usp_Insert = "usp_InsertUser";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@userId", user.user_id, direction: ParameterDirection.Input);
                parameters.Add("@userName", user.user_name, direction: ParameterDirection.Input);
                parameters.Add("@userEmail", user.user_email, direction: ParameterDirection.Input);
                parameters.Add("@userPwd", user.user_pwd, direction: ParameterDirection.Input);
                parameters.Add("@userPhone", user.user_phone, direction: ParameterDirection.Input);
                parameters.Add("@userAge", user.user_age, direction: ParameterDirection.Input);
                parameters.Add("@userImage", user.user_ImagePath, direction: ParameterDirection.Input);

                userID = UnitOfWork.Connection.ExecuteScalar<int>(usp_Insert, parameters, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex) {
                Console.WriteLine("Exception is " + ex.Message);
            }
            return userID;
        }

        public void DeleteAddress(int id)
        {
            const string usp_Delete = "usp_delUserAddress";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserIdFK", id, direction: ParameterDirection.Input);
            UnitOfWork.Connection.QueryFirstOrDefault(usp_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRecord(int id)
        {
            const string usp_Delete = "usp_DeleteUser";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", id, direction: ParameterDirection.Input);
            UnitOfWork.Connection.QueryFirstOrDefault(usp_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public UserAddress GetAddressById(int id)
        {
            UserAddress objAdd = null;
            try
            {
                const string usp_EditAddress = "usp_EditAddress";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@userIDFK", id, direction: ParameterDirection.Input);
                objAdd = UnitOfWork.Connection.QueryFirstOrDefault<UserAddress>(usp_EditAddress, parameters, commandType: CommandType.StoredProcedure);
                
            }catch(Exception ex)
            {
                Console.WriteLine("Exception is " + ex.Message);
            }
            return objAdd;
        }

        public Users GetbyId(int id)
        {
            const string usp_EditUser = "usp_EditUser";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userID", id, direction: ParameterDirection.Input);
            Users objUser = UnitOfWork.Connection.QueryFirstOrDefault<Users>(usp_EditUser, parameters, commandType: CommandType.StoredProcedure);
            return objUser;
        }

        public List<Users> GetUsers()
        {
            List<Users> userList = null;
            try {
                const string usp_UserList = "usp_GetUsersList";
                userList = UnitOfWork.Connection.Query<Users>(usp_UserList, commandType: CommandType.StoredProcedure).ToList();
                //userList = UnitOfWork.Connection.Query<Users>(usp_UserList, commandType: CommandType.StoredProcedure).ToList();
            }catch(Exception e)
            {
                Console.WriteLine("Exception is " + e.Message);
            }
            return userList;
            
        }

        public int SaveAddress(UserAddress userAd)
        {
            int addressId = 0;
            try
            {
                const string usp_address = "usp_UserAddress";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@cityName", userAd.city_name, direction: ParameterDirection.Input);
                parameters.Add("@userIDFK", userAd.userID, direction: ParameterDirection.Input);
                 addressId = UnitOfWork.Connection.ExecuteScalar<int>(usp_address,parameters, commandType: CommandType.StoredProcedure);
            }catch(Exception ex) {

                Console.WriteLine("Your Exception is=> " + ex.Message);
            
            }
            return addressId;
        }

        public int UpdateAddress(int rcrd, UserAddress objAd)
        {
            int userID = 0;
            //Users objUser = user;
            try
            {
                const string usp_address = "usp_UserAddress";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@cityName", objAd.city_name, direction: ParameterDirection.Input);
                parameters.Add("@userIDFK", objAd.userID, direction: ParameterDirection.Input);
                userID = UnitOfWork.Connection.ExecuteScalar<int>(usp_address, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your Exception is=> " + ex.Message);
            }
            return userID;
        }

        public int UpdateUser(int id, Users user)
        {
            int userID = 0;
            //Users objUser = user;
            try
            {
                const string usp_Insert = "usp_InsertUser";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@userId", user.user_id, direction: ParameterDirection.Input);
                parameters.Add("@userName", user.user_name, direction: ParameterDirection.Input);
                parameters.Add("@userEmail", user.user_email, direction: ParameterDirection.Input);
                parameters.Add("@userPwd", user.user_pwd, direction: ParameterDirection.Input);
                parameters.Add("@userPhone", user.user_phone, direction: ParameterDirection.Input);
                parameters.Add("@userAge", user.user_age, direction: ParameterDirection.Input);
                parameters.Add("@userImage", user.user_ImagePath, direction: ParameterDirection.Input);
                userID = UnitOfWork.Connection.ExecuteScalar<int>(usp_Insert, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                Console.WriteLine("Your Exception is=> " + ex.Message);
            }
            return userID;
        }
    }
}
