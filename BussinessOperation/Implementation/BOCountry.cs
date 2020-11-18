using BussinessOperation.Interfaces;
using Inferastructure.DataModels;
using System;
using System.Collections.Generic;
using Services.Interfaces;
using System.Text;

namespace BussinessOperation.Implementation
{
    public class BOCountry : IBOCountry
    {
        private readonly ICountryService _countryService;
        public BOCountry(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<Country> GetCountryLists()
        {
            return _countryService.GetCountryLists();
        }

        public List<ProvinceModel> GetProvinceLists()
        {
            return _countryService.GetProvinceLists();
        }

        public List<SkillsModel> GetSkillsLists()
        {
            return _countryService.GetSkillsLists();
        }
    }
}
