using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedixCollege.Controllers
{
    public class DiscoverMedixController : Controller
    {
        // GET: DiscoverMedix
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

        // GET: History
        public ActionResult History()
        {
            return View();
        }

        // GET: Laptop Initiative
        public ActionResult LaptopInitiative()
        {
            return View();
        }

        // GET: Transcript Request
        public ActionResult TranscriptRequest()
        {
            return View();
        }

        public ActionResult VirtualTour()
        {
            return View();
        }

        public ActionResult CareersAtMedix()
        {
            return View();
        }
    }
}