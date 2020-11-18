using Dapper;
using demo_master.Models;
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
    public class CountryRepository : ICountryRepository
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public List<Country> GetCountryList()
        {
            List<Country> countryList = null;
            try
            {
                const string usp_CountryList = "usp_GetCountryList";
                countryList = UnitOfWork.Connection.Query<Country>(usp_CountryList, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is " + e.Message);
            }
            return countryList;
        }

        public List<ProvinceModel> GetProvinceLists()
        {
            List<ProvinceModel> provinceList = null;
            try
            {
                const string usp_GetProvinceList = "usp_GetProvinceList";
                provinceList = UnitOfWork.Connection.Query<ProvinceModel>(usp_GetProvinceList, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is " + e.Message);
            }
            return provinceList;
        }

        public List<SkillsModel> GetSkillsLists()
        {
            List<SkillsModel> skillsList = null;
            try
            {
                const string usp_GetSkills = "usp_GetSkills";
                skillsList = UnitOfWork.Connection.Query<SkillsModel>(usp_GetSkills, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is " + e.Message);
            }
            return skillsList;
        }
    }
}
