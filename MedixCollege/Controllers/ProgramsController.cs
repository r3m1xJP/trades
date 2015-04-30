using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedixCollege.Controllers
{
    public class ProgramsController : Controller
    {
        // GET: Programs
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

        // GET: HVACTechnician
        public ActionResult HVACTechnician()
        {
            return View();
        }

        // GET: Welding
        public ActionResult Welding()
        {
            return View();
        }

        // GET: SolarEnergyTechnician
        public ActionResult SolarEnergyTechnician()
        {
            return View();
        }

        // GET: Cabinetmaking
        public ActionResult Cabinetmaking()
        {
            return View();
        }

        // GET: HomeRenovationTechnician
        public ActionResult HomeRenovationTechnician()
        {
            return View();
        }

        // GET: IndustrialAndCommericalMaintenance
        public ActionResult IndustrialAndCommericalMaintenance()
        {
            return View();
        }

        // GET: MotorcycleAndSmallEngineRepair
        public ActionResult MotorcycleAndSmallEngineRepair()
        {
            return View();
        }

        // GET: ConstructionAndMaintenanceElectrician
        public ActionResult ConstructionAndMaintenanceElectrician()
        {
            return View();
        }

        // GET: ElectricalTechnology
        public ActionResult ElectricalTechnology()
        {
            return View();
        }

        // GET: All Programs
        public ActionResult AllPrograms()
        {
            ViewBag.SideHeader = "Test";
            ViewBag.SideSubHeader1 = "Test1";
            ViewBag.SideSubText1 = "Test2";
            ViewBag.SideSubHeader2 = "Test3";
            ViewBag.SideSubText2 = "Test4";
            ViewBag.SideSubHeader3 = "Test5";
            ViewBag.SideSubText3 = "Test6";

            return View();
        }
    }
}