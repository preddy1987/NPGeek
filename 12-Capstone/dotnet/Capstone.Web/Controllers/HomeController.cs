using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using SessionControllerData;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : SessionController
    {
        private INPGeekDAL dal;

        public HomeController(INPGeekDAL dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ParkList parkList = new ParkList();
            parkList.Parks.AddRange(dal.GetAllParks());
            return View("Index", parkList);
        }

        public IActionResult Detail(string parkCode = "CVNP")
        {
            return View(dal.GetPark(parkCode));
        }

        [HttpGet]
        public IActionResult Survey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Survey(Survey survey)
        {
            IActionResult result = null;

            TempData["Username"] = survey.SurveyID;

            if (!ModelState.IsValid)
            {
                result = View("Survey_Results");
            }
            else
            {
                dal.SaveNewSurvey(survey);
                result = RedirectToAction("Survey", "Home");
            }

            return result;
        }

        public IActionResult Survey_Results()
        {
            return View(dal.GetAllSurveys());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
