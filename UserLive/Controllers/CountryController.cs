using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BussinessOperation.Interfaces;
using UserLive.Models;
using Newtonsoft.Json;

namespace UserLive.Controllers
{
    public class CountryController : Controller
    {
        private readonly IBOCountry _IBOCountry;
        public CountryController(IBOCountry IBOCountry)
        {
            _IBOCountry = IBOCountry;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetCountryLists()
        {
            //var sa = new JsonSerializerSettings();
            var list = _IBOCountry.GetCountryLists();
            List<CountryVM> objList = new List<CountryVM>();
            foreach (var item in list)
            {
                var cvm = new CountryVM()
                {
                    countryId = item.countryId,
                    countryName = item.countryName
                };
                objList.Add(cvm);


            }
            var obj = objList;
            return Json(obj, new JsonSerializerSettings());
        }

        public JsonResult GetProvinceLists()
        {
            //var sa = new JsonSerializerSettings();
            var list = _IBOCountry.GetProvinceLists();
            List<ProvinceVM> objList = new List<ProvinceVM>();
            foreach (var item in list)
            {
                var pvm = new ProvinceVM()
                {
                    countryId = item.countryId,
                    provinceId=item.provinceId,
                    provinceName=item.provinceName
                };
                objList.Add(pvm);


            }
            return Json(objList, new JsonSerializerSettings());
        }

        public JsonResult GetSkillsLists()
        {
            //var sa = new JsonSerializerSettings();
            var list = _IBOCountry.GetSkillsLists();
            List<SkillsVM> objList = new List<SkillsVM>();
            foreach (var item in list)
            {
                var svm = new SkillsVM()
                {
                   skillId=item.skillId,
                   skillName=item.skillName
                };
                objList.Add(svm);


            }
            return Json(objList, new JsonSerializerSettings());
        }
    }
}
