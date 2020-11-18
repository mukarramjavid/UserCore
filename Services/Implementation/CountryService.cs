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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryRepository _countryRepository;
        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
            _countryRepository.UnitOfWork = unitOfWork;

        }
        public List<Country> GetCountryLists()
        {
            List<Country> objList = new List<Country>();
            _unitOfWork.Open();

            objList = _countryRepository.GetCountryList();

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

        public List<SkillsModel> GetSkillsLists()
        {
            List<SkillsModel> objList = new List<SkillsModel>();
            _unitOfWork.Open();

            objList = _countryRepository.GetSkillsLists();

            _unitOfWork.Close();
            return objList;
        }

        public List<ProvinceModel> GetProvinceLists()
        {
            List<ProvinceModel> objList = new List<ProvinceModel>();
            _unitOfWork.Open();

            objList = _countryRepository.GetProvinceLists();

            _unitOfWork.Close();
            return objList;
        }
    }
}
