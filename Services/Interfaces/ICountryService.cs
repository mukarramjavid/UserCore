using demo_master.Models;
using Inferastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICountryService : IDisposable
    {
        List<Country> GetCountryLists();
        List<SkillsModel> GetSkillsLists();
        List<ProvinceModel> GetProvinceLists();
    }
}
