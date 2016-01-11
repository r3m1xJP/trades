using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedixCollege.Controllers
{
    public class CareerServicesController : Controller
    {
        // GET: CareerServices
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

        // GET: MedixAdvantage
        public ActionResult NATSAdvantage()
        {
            return View();
        }

        public ActionResult JobSearchTips()
        {
            return View();
        }

        public ActionResult ResumeTips()
        {
            return View();
        }

        public ActionResult InterviewTips()
        {
            return View();
        }

        public ActionResult ProfessionalTips()
        {
            return View();
        }

        public ActionResult HireAGrad()
        {
            return View();
        } 
    }
}