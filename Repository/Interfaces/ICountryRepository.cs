using Inferastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICountryRepository : IBaseRepository
    {
        List<Country> GetCountryList();
        List<SkillsModel> GetSkillsLists();
        List<ProvinceModel> GetProvinceLists();
    }
}
