using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedixCollege.Controllers
{
    public class CampusesController : Controller
    {
        // GET: All Campuses
        public ActionResult Index()
        {
            ViewBag.HeroText = "";
            ViewBag.BodyHeaderText = "";

            ViewBag.SideHeader = "Test";
            ViewBag.SideSubHeader1 = "Test1";
            ViewBag.SideSubText1 = "Test2";
            ViewBag.SideSubHeader2 = "Test3";
            ViewBag.SideSubText2 = "Test4";
            ViewBag.SideSubHeader3 = "Test5";
            ViewBag.SideSubText3 = "Test6";

            return View();
        }

        // GET: Brampton
        public ActionResult Brampton()
        {
            return View();
        }

        // GET: Brantford
        public ActionResult Brantford()
        {
            return View();
        }

        // GET: Kitchener
        public ActionResult Kitchener()
        {
            return View();
        }

        // GET: London
        public ActionResult London()
        {
            return View();
        }

        // GET: Scarborough
        public ActionResult Scarborough()
        {
            return View();
        }

        // GET: Toronto
        public ActionResult Toronto()
        {
            return View();
        }
    }
}