using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradesCollege.Models;

namespace MedixCollege.Controllers
{
    public class LeadsController : Controller
    {
        // GET: Leads
        public ActionResult Index()
        {
            var leads = new Leads();

            return View(leads.Get());
        }
    }
}