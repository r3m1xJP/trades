using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradesCollege.Models;
using PagedList;
using MedixCollege.Helpers;

namespace MedixCollege.Controllers
{
    public class LeadsController : Controller
    {
        public Dictionary<int, string> programs = new Dictionary<int, string>();
        public Dictionary<int, string> mediaSources = new Dictionary<int, string>();
        public LeadsController()
        {
            programs.Add(38882, "Anatomy & Physiology");
            programs.Add(39877, "Child and Youth Care with Addictions Support Worker");
            programs.Add(632, "Community Service Worker");
            programs.Add(39478, "CPR & First Aid");
            programs.Add(818, "Dental Level 2");
            programs.Add(38883, "Dental Office Procedures (abel dent)");
            programs.Add(634, "Developmental Service Worker");
            programs.Add(38526, "Early Childhood Assistant");
            programs.Add(642, "ECG");
            programs.Add(37255, "Fitness & Health Promotion");
            programs.Add(39162, "Intramuscular Injection");
            programs.Add(627, "Intra-Oral Dental Assistant ");
            programs.Add(629, "Massage Therapy");
            programs.Add(633, "Medical Laboratory Assistant / Technician");
            programs.Add(630, "Medical Office Administrator");
            programs.Add(1170, "Medical Terminology");
            programs.Add(38887, "Medical Transcription");
            programs.Add(39415, "Mental Health & Addictions");
            programs.Add(1169, "OHIP Billing");
            programs.Add(631, "Personal Support Worker");
            programs.Add(628, "Pharmacy Assistant");
            programs.Add(636, "Phlebotomy");
            programs.Add(1167, "Principles of Nutrition");
            programs.Add(643, "PSW Upgrading");
            programs.Add(1171, "Thought Patterns");

            mediaSources.Add(91063, "HIGH SCHOOL");
            mediaSources.Add(90080, "INTERNET");
            mediaSources.Add(90081, "NEWSPAPER");
            mediaSources.Add(91092, "OUTREACH");
            mediaSources.Add(90213, "RADIO");
            mediaSources.Add(90083, "REFERRAL");
            mediaSources.Add(91051, "SEARCH ENGINE MARKETING");
            mediaSources.Add(91044, "SIGNS");
            mediaSources.Add(91241, "SUBWAY");
            mediaSources.Add(90082, "TELEVISION");
            mediaSources.Add(90825, "TRADE SHOWS");
            mediaSources.Add(90084, "VENDOR");
        }

        // GET: Leads
        public ActionResult Index(string pageValid, string dateTimeFilter, string campusFilter, string programFilter, string mediaSourceFilter, bool clearFilter = false, int page = 1)
        {
            if (clearFilter)
            {
                dateTimeFilter = "All";
                campusFilter = "All";
                programFilter = "All";
                mediaSourceFilter = "All";
            }

            ViewBag.DateTimeFilterText = dateTimeFilter;
            ViewBag.CampusFilterText = campusFilter;
            ViewBag.ProgramFilter = programFilter;
            ViewBag.MediaSourceFilter = mediaSourceFilter;
            ViewBag.PageValid = string.IsNullOrEmpty(pageValid) ? "false" : pageValid;

            var leads = new Leads();

            var leadsList = leads.Get();

            if (dateTimeFilter != "All" && !string.IsNullOrEmpty(dateTimeFilter))
            {
                DateTime dateFilter;
                DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                switch (dateTimeFilter)
                {
                    case "Today":
                        dateFilter = todaysDate;
                        break;
                    case "Yesterday":
                        dateFilter = todaysDate.AddDays(-1);
                        break;
                    case "LastWeek":
                        dateFilter = todaysDate.AddDays(-7);
                        break;
                    case "LastMonth":
                        dateFilter = todaysDate.AddDays(-30);
                        break;
                    case "LastYear":
                        dateFilter = todaysDate.AddDays(-365);
                        break;
                    default:
                        dateFilter = DateTime.Now;
                        break;
                }

                leadsList = leadsList.Where(x => x.Date >= dateFilter).ToList();
            }

            if (campusFilter != "All" && !string.IsNullOrEmpty(campusFilter))
            {
                leadsList = leadsList.Where(x => x.Location.ToUpper() == campusFilter.ToUpper()).ToList();
            }

            if (programFilter != "All" && !string.IsNullOrEmpty(programFilter))
            {
                var program = programs.FirstOrDefault(x => x.Key.ToString() == programFilter);

                if (program.Value != null)
                {
                    leadsList = leadsList.Where(x => x.Program.ToUpper() == program.Value.ToUpper()).ToList();
                }
            }

            if (mediaSourceFilter != "All" && !string.IsNullOrEmpty(mediaSourceFilter))
            {
                var mediaSource = mediaSources.FirstOrDefault(x => x.Key.ToString() == mediaSourceFilter);

                if (mediaSource.Value != null)
                {
                    leadsList = leadsList.Where(x => x.HearAbout.ToUpper() == mediaSource.Value.ToUpper()).ToList();
                }
            }

            int pageSize = 25;

            return View(leadsList.ToPagedList(page, pageSize));
        }

        // GET: Baltimore
        public ActionResult Baltimore(string pageValid, string dateTimeFilter, string campusFilter, string programFilter, string mediaSourceFilter, bool clearFilter = false, int page = 1)
        {
            if (clearFilter)
            {
                dateTimeFilter = "All";
                campusFilter = "All";
                programFilter = "All";
                mediaSourceFilter = "All";
            }

            ViewBag.LeadsType = "Baltimore";
            ViewBag.DateTimeFilterText = dateTimeFilter;
            ViewBag.CampusFilterText = campusFilter;
            ViewBag.ProgramFilter = programFilter;
            ViewBag.MediaSourceFilter = mediaSourceFilter;
            ViewBag.PageValid = string.IsNullOrEmpty(pageValid) ? "false" : pageValid;

            var leads = new Leads(LeadsType.LeadsBaltimore);

            var leadsList = leads.Get();

            if (dateTimeFilter != "All" && !string.IsNullOrEmpty(dateTimeFilter))
            {
                DateTime dateFilter;
                DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                switch (dateTimeFilter)
                {
                    case "Today":
                        dateFilter = todaysDate;
                        break;
                    case "Yesterday":
                        dateFilter = todaysDate.AddDays(-1);
                        break;
                    case "LastWeek":
                        dateFilter = todaysDate.AddDays(-7);
                        break;
                    case "LastMonth":
                        dateFilter = todaysDate.AddDays(-30);
                        break;
                    case "LastYear":
                        dateFilter = todaysDate.AddDays(-365);
                        break;
                    default:
                        dateFilter = DateTime.Now;
                        break;
                }

                leadsList = leadsList.Where(x => x.Date >= dateFilter).ToList();
            }

            if (campusFilter != "All" && !string.IsNullOrEmpty(campusFilter))
            {
                leadsList = leadsList.Where(x => x.Location.ToUpper() == campusFilter.ToUpper()).ToList();
            }

            if (programFilter != "All" && !string.IsNullOrEmpty(programFilter))
            {
                var program = programs.FirstOrDefault(x => x.Key.ToString() == programFilter);

                if (program.Value != null)
                {
                    leadsList = leadsList.Where(x => x.Program.ToUpper() == program.Value.ToUpper()).ToList();
                }
            }

            if (mediaSourceFilter != "All" && !string.IsNullOrEmpty(mediaSourceFilter))
            {
                var mediaSource = mediaSources.FirstOrDefault(x => x.Key.ToString() == mediaSourceFilter);

                if (mediaSource.Value != null)
                {
                    leadsList = leadsList.Where(x => x.HearAbout.ToUpper() == mediaSource.Value.ToUpper()).ToList();
                }
            }

            int pageSize = 25;

            return View("Index", leadsList.ToPagedList(page, pageSize));
        }

        // GET: Newacastle
        public ActionResult Newcastle(string pageValid, string dateTimeFilter, string campusFilter, string programFilter, string mediaSourceFilter, bool clearFilter = false, int page = 1)
        {
            if (clearFilter)
            {
                dateTimeFilter = "All";
                campusFilter = "All";
                programFilter = "All";
                mediaSourceFilter = "All";
            }

            ViewBag.LeadsType = "Newcastle";
            ViewBag.DateTimeFilterText = dateTimeFilter;
            ViewBag.CampusFilterText = campusFilter;
            ViewBag.ProgramFilter = programFilter;
            ViewBag.MediaSourceFilter = mediaSourceFilter;
            ViewBag.PageValid = string.IsNullOrEmpty(pageValid) ? "false" : pageValid;

            var leads = new Leads(LeadsType.LeadsNewCastle);

            var leadsList = leads.Get();

            if (dateTimeFilter != "All" && !string.IsNullOrEmpty(dateTimeFilter))
            {
                DateTime dateFilter;
                DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                switch (dateTimeFilter)
                {
                    case "Today":
                        dateFilter = todaysDate;
                        break;
                    case "Yesterday":
                        dateFilter = todaysDate.AddDays(-1);
                        break;
                    case "LastWeek":
                        dateFilter = todaysDate.AddDays(-7);
                        break;
                    case "LastMonth":
                        dateFilter = todaysDate.AddDays(-30);
                        break;
                    case "LastYear":
                        dateFilter = todaysDate.AddDays(-365);
                        break;
                    default:
                        dateFilter = DateTime.Now;
                        break;
                }

                leadsList = leadsList.Where(x => x.Date >= dateFilter).ToList();
            }

            if (campusFilter != "All" && !string.IsNullOrEmpty(campusFilter))
            {
                leadsList = leadsList.Where(x => x.Location.ToUpper() == campusFilter.ToUpper()).ToList();
            }

            if (programFilter != "All" && !string.IsNullOrEmpty(programFilter))
            {
                var program = programs.FirstOrDefault(x => x.Key.ToString() == programFilter);

                if (program.Value != null)
                {
                    leadsList = leadsList.Where(x => x.Program.ToUpper() == program.Value.ToUpper()).ToList();
                }
            }

            if (mediaSourceFilter != "All" && !string.IsNullOrEmpty(mediaSourceFilter))
            {
                var mediaSource = mediaSources.FirstOrDefault(x => x.Key.ToString() == mediaSourceFilter);

                if (mediaSource.Value != null)
                {
                    leadsList = leadsList.Where(x => x.HearAbout.ToUpper() == mediaSource.Value.ToUpper()).ToList();
                }
            }

            int pageSize = 25;

            return View("Index", leadsList.ToPagedList(page, pageSize));
        }

        public JsonResult CheckLogin(string username, string password)
        {
            var valid = false;

            if (username == "ralary" && password == "packers")
            {
                valid = true;
            }

            if (username == "newcastle15" && password == "ravens1")
            {
                valid = true;
            }

            if (username == "newcastle15" && password == "steelers1")
            {
                valid = true;
            }

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }
    }
}