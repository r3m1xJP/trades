using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedixCollege.Controllers
{
    public class DiscoverNATSController : Controller
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

        // GET: Presidents Message
        public ActionResult PresidentsMessage()
        {
            return View();
        }

        // GET: Mission
        public ActionResult Mission()
        {
            return View();
        }

        public ActionResult Accreditation()
        {
            return View();
        }

        public ActionResult Associations()
        {
            return View();
        }

        public ActionResult PartnerSchools()
        {
            return View();
        }

        public ActionResult CareersAtNATS()
        {
            return View();
        }
    }
}