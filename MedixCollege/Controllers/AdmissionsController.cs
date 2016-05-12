using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedixCollege.Controllers
{
    public class AdmissionsController : Controller
    {
        // GET: Admissions
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

        // GET: EmploymentOntario
        public ActionResult EmploymentOntario()
        {
            return View();
        }

        // GET: LifelongLearningPlan
        public ActionResult LifelongLearningPlan()
        {
            return View();
        }

        // GET: OSAP
        public ActionResult OSAP()
        {
            return View();
        }

        // GET: OutOfProvinceStudents
        public ActionResult OutOfProvinceStudents()
        {
            return View();
        }

        // GET: RegisteredEducationSavingsPlans
        public ActionResult RegisteredEducationSavingsPlans()
        {
            return View();
        }

        // GET: SecondCareers
        public ActionResult SecondCareers()
        {
            return View();
        }

        // GET: StudentLinesOfCredit
        public ActionResult StudentLinesOfCredit()
        {
            return View();
        }

        // GET: FinancialOptions
        public ActionResult FinancialOptions()
        {
            return View();
        }

        // GET: CanadaJobGrant
        public ActionResult CanadaJobGrant()
        {
            return View();
        }

        // GET: MonthlyPaymentPlan
        public ActionResult MonthlyPaymentPlan()
        {
            return View();
        }
    }
}