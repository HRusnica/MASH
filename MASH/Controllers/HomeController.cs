using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MASH.DAL;
using MASH.Models;

namespace MASH.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ThemeDAL dal = new ThemeDAL();
            List<Theme> model = dal.GetAllThemes();
            return View(model);
        }

        [HttpGet]
        public ActionResult MashUp(string themeSelection, int isGirl)
        {
            //return themeSelection + isGirl;
            if (themeSelection == "custom")
            {
                return View("MashUp");
            }
            else
            {
                FutureGroupDAL dal = new FutureGroupDAL();
                List<FutureGroup> model = dal.GetAllGroups(themeSelection, isGirl);

                return View("FindFuture", model);
            }
        }

        [HttpGet]
        public ActionResult Calculate(int iterator)
        {
            CalculateDAL dal = new CalculateDAL();
            string model = dal.getPrediction(iterator);
            return View("Calculate", model);
        }
    }
}