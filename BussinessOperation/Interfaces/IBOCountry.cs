using Inferastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessOperation.Interfaces
{
    public interface IBOCountry
    {
        List<Country> GetCountryLists();
        List<SkillsModel> GetSkillsLists();
        List<ProvinceModel> GetProvinceLists();
    }
    
}
