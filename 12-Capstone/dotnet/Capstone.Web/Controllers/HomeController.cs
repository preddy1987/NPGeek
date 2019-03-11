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

        public IActionResult Index()
        {    
            return View(dal.GetAllParks());
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Survey()
        {
            return View();
        }
      
        public IActionResult FavPark()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
