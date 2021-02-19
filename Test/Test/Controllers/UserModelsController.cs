using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class UserModelsController : Controller
    {
        private readonly TestDbContext _testDbContext;

        public UserModelsController(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public IActionResult Step1()
        {
            UserModel user = new UserModel
            {
                Area = IsCheckList()
            };
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
           
            return View();
        }

        public IActionResult Step2()
        {
            return View();
        }

        public IActionResult Step3()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Stage1(ContactInfoModel contactInfo, string previousBtn, string nextBtn)
        {
            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("user"));

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    userModel.Id = contactInfo.Id;
                    userModel.FirstName = contactInfo.FirstName;
                    userModel.MiddleName = contactInfo.MiddleName;
                    userModel.LastName = contactInfo.LastName;
                    userModel.Company = contactInfo.Company;
                    userModel.Title = contactInfo.Title;
                    userModel.Email = contactInfo.Email;
                    userModel.Phone = contactInfo.Phone;
                    userModel.Fax = contactInfo.Fax;
                    userModel.Mobile = contactInfo.Mobile;

                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(userModel));

                    return View("Step2", userModel);
                }
            }

            return View("Step1",userModel);
        }

        [HttpPost]
        public ActionResult Stage2(AreasModel areasModel, string previousBtn, string nextBtn)
        {
            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("user"));

            if (previousBtn != null)
            {
                userModel.Area = areasModel.Area;
                userModel.Comments = areasModel.Comments;

                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(userModel));

                return View("Step1", userModel);
            }

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    userModel.Area = areasModel.Area;
                    userModel.Comments = areasModel.Comments;

                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(userModel));

                    return View("Step3", userModel);
                }
            }

            return View("Step2", userModel);
        }

        [HttpPost]
        public ActionResult Stage3(AddressModel addressModel, string previousBtn, string nextBtn)
        {
            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("user"));

            if (previousBtn != null)
            {
                userModel.Country = addressModel.Country;
                userModel.OfficeName = addressModel.OfficeName;
                userModel.Address = addressModel.Address;
                userModel.PostalCode = addressModel.PostalCode;
                userModel.City = addressModel.City;
                userModel.State = addressModel.State;

                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(userModel));

                return View("Step2", userModel);
            }

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    userModel.Country = addressModel.Country;
                    userModel.OfficeName = addressModel.OfficeName;
                    userModel.Address = addressModel.Address;
                    userModel.PostalCode = addressModel.PostalCode;
                    userModel.City = addressModel.City;
                    userModel.State = addressModel.State;

                    foreach (var i in userModel.Area)
                    {
                        if (i.Selected==true)
                        {
                             _testDbContext.Areas.Add(i);
                        }
                    }
                    _testDbContext.Users.Add(userModel);
                    _testDbContext.SaveChanges();

                    return View("Success");
                }
            }

            return View("Step3", userModel);
        }

        public List<Area> IsCheckList()
        {
            List<Area> areasList = new List<Area>
            {
                new() {AreaName = "Finance"},
                new() {AreaName = "Operations"},
                new() {AreaName = "IT"},
                new() {AreaName = "Sales"},
                new() {AreaName = "Administrative"},
                new() {AreaName = "Legal"},
                new() {AreaName = "Marketing"}
            };

            return areasList;
        }
    }
}