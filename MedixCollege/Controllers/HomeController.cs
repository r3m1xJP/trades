using MedixCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MedixCollege.Controllers
{
    public class HomeController : Controller
    {
        public Dictionary<int, string> campuses = new Dictionary<int, string>();
        public Dictionary<int, string> programs = new Dictionary<int, string>();
        public Dictionary<int, string> mediaSources = new Dictionary<int, string>();

        public HomeController()
        {
            campuses.Add(246, "Brampton");
            campuses.Add(243, "Brantford");
            campuses.Add(242, "Kitchener");
            campuses.Add(244, "London");
            campuses.Add(241, "Scarborough");
            campuses.Add(240, "Toronto");

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
            mediaSources.Add(91044, "SIGNS");
            mediaSources.Add(91241, "SUBWAY");
            mediaSources.Add(90082, "TELEVISION");
            mediaSources.Add(90825, "TRADE SHOWS");
        }
        public ActionResult Index()
        {
            var newsArticle = new NewsArticle();

            ViewBag.NewsArticles = newsArticle.Get().ToList();

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SiteMap()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult AccessibilityPolicy()
        {
            return View();
        }

        public ActionResult CareersAtMedix()
        {
            return View();
        }

        public ActionResult HireAGrad()
        {
            return View();
        }

        public ActionResult VirtualTours()
        {
            return View();
        }

        public ActionResult SocialMedia()
        {
            return View();
        }

        public ActionResult ReferralProgram()
        {
            return View();
        }

        public ActionResult CourseStartDates()
        {
            return View();
        }


        public ActionResult NewsDirectory()
        {
            var newsArticle = new NewsArticle();

            return View(newsArticle.Get().ToList());
        }

        public ActionResult NewsArticle(int id = 0)
        {
            ViewBag.NewsDate = DateTime.Now;

            if (id > 0)
            {
                var newsArticle = new NewsArticle(id);

                ViewBag.Title = newsArticle.NewsArticleDTO.Title;

                ViewBag.NewsDate = newsArticle.NewsArticleDTO.Date;

                ViewBag.NewsBody = newsArticle.NewsArticleDTO.Body;
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ApplyNow(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                ViewBag.Success = true;

                try
                {
                    using (var mailClient = new SmtpClient("smtp.gmail.com"))
                    {
                        mailClient.Credentials = new NetworkCredential("ccgactiveleads", "Medixcollege1");
                        mailClient.Port = 587;

                        var message = new MailMessage();

                        message.From = new MailAddress("ccgactiveleads@gmail.com", "MedixCollege.net");

                        message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                        if (fc["CampusID"].ToString() == "246")
                        {
                            message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                        }

                        if (fc["CampusID"].ToString() == "243")
                        {
                            message.To.Add(new MailAddress("jlaird@medixcollege.ca"));
                            message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                        }

                        if (fc["CampusID"].ToString() == "242")
                        {
                            message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                        }

                        if (fc["CampusID"].ToString() == "244")
                        {
                            message.To.Add(new MailAddress("ngauvin@medixschool.ca"));
                            message.To.Add(new MailAddress("nicole@medixschool.ca"));
                        }

                        if (fc["CampusID"].ToString() == "241")
                        {
                            message.To.Add(new MailAddress("dickson@medixcollege.ca"));
                        }

                        if (fc["CampusID"].ToString() == "240")
                        {
                            message.To.Add(new MailAddress("chris@medixcollege.ca"));
                        }

                        message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));
                        message.Bcc.Add(new MailAddress("pdykstra@medixcollege.ca"));
                        message.Bcc.Add(new MailAddress("ralary@natradeschools.ca"));

                        message.Subject = "New Lead - Medix - Apply Now";

                        var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                        var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                        var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;

                        fc["CampusID"] = campus ?? fc["CampusID"];
                        fc["ProgramID"] = program ?? fc["ProgramID"];
                        fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];

                        var stringArray = (from key in fc.AllKeys
                                           from value in fc.GetValues(key)
                                           where key != "ORGID" && key != "MailListID"
                                           select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                        var body = "New Lead - Medix" + Environment.NewLine +
                                   Environment.NewLine;

                        var data = string.Join(",", stringArray).Replace(",", "");

                        data = data.Replace("CampusID", "Location");
                        data = data.Replace("FirstName", "First Name");
                        data = data.Replace("Lastname", "Last Name");
                        data = data.Replace("MediaGroupID", "Media Source");
                        data = data.Replace("ProgramID", "Program");
                        data = data.Replace("Comment2", "Comments");

                        message.Body = body + data;
                        message.IsBodyHtml = false;

                        mailClient.EnableSsl = true;
                        mailClient.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = ex.Message.ToString();
                }
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> TourCampus(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;

                    try
                    {
                        using (var mailClient = new SmtpClient("smtp.gmail.com"))
                        {
                            mailClient.Credentials = new NetworkCredential("ccgactiveleads", "Medixcollege1");
                            mailClient.Port = 587;

                            var message = new MailMessage();

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "MedixCollege.net");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "246")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "243")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("jlaird@medixcollege.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "242")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "244")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("ngauvin@medixschool.ca"));
                                message.To.Add(new MailAddress("nicole@medixschool.ca"));
                            }

                            if (fc["CampusID"].ToString() == "241")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("dickson@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "240")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("chris@medixcollege.ca"));
                            }

                            message.Subject = "New Lead - Medix - Book A Tour";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Medix" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Source");
                            data = data.Replace("ProgramID", "Program");
                            data = data.Replace("Comment2", "Comments");

                            message.Body = body + data;
                            message.IsBodyHtml = false;

                            mailClient.EnableSsl = true;
                            mailClient.Send(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Success = false;

                        ViewBag.ErrorMessage = ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AskQuestionProgram(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;

                    try
                    {
                        using (var mailClient = new SmtpClient("smtp.gmail.com"))
                        {
                            mailClient.Credentials = new NetworkCredential("ccgactiveleads", "Medixcollege1");
                            mailClient.Port = 587;

                            var message = new MailMessage();

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "MedixCollege.net");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "246")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "243")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("jlaird@medixcollege.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "242")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "244")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("ngauvin@medixschool.ca"));
                                message.To.Add(new MailAddress("nicole@medixschool.ca"));
                            }

                            if (fc["CampusID"].ToString() == "241")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("dickson@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "240")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("chris@medixcollege.ca"));
                            }

                            message.Subject = "New Lead - Medix - Program Question";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Medix" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Source");
                            data = data.Replace("ProgramID", "Program");
                            data = data.Replace("Comment2", "Comments");

                            message.Body = body + data;
                            message.IsBodyHtml = false;

                            mailClient.EnableSsl = true;
                            mailClient.Send(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Success = false;

                        ViewBag.ErrorMessage = ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AskQuestionCertificate(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;

                    try
                    {
                        using (var mailClient = new SmtpClient("smtp.gmail.com"))
                        {
                            mailClient.Credentials = new NetworkCredential("ccgactiveleads", "Medixcollege1");
                            mailClient.Port = 587;

                            var message = new MailMessage();

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "MedixCollege.net");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "246")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "243")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("jlaird@medixcollege.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "242")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "244")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("ngauvin@medixschool.ca"));
                                message.To.Add(new MailAddress("nicole@medixschool.ca"));
                            }

                            if (fc["CampusID"].ToString() == "241")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("dickson@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "240")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("chris@medixcollege.ca"));
                            }

                            message.Subject = "New Lead - Medix - Certificate Question";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Medix" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Source");
                            data = data.Replace("ProgramID", "Program");
                            data = data.Replace("Comment2", "Comments");

                            message.Body = body + data;
                            message.IsBodyHtml = false;

                            mailClient.EnableSsl = true;
                            mailClient.Send(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Success = false;

                        ViewBag.ErrorMessage = ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> RequestCatalogue(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;

                    try
                    {
                        using (var mailClient = new SmtpClient("smtp.gmail.com"))
                        {
                            mailClient.Credentials = new NetworkCredential("ccgactiveleads", "Medixcollege1");
                            mailClient.Port = 587;

                            var message = new MailMessage();

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "MedixCollege.net");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "246")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "243")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("jlaird@medixcollege.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "242")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "244")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("ngauvin@medixschool.ca"));
                                message.To.Add(new MailAddress("nicole@medixschool.ca"));
                            }

                            if (fc["CampusID"].ToString() == "241")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("dickson@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "240")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("chris@medixcollege.ca"));
                            }

                            message.Subject = "New Lead - Medix - Request Catalogue";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Medix" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Source");
                            data = data.Replace("ProgramID", "Program");
                            data = data.Replace("Comment2", "Comments");

                            message.Body = body + data;
                            message.IsBodyHtml = false;

                            mailClient.EnableSsl = true;
                            mailClient.Send(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Success = false;

                        ViewBag.ErrorMessage = ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AskQuestion(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;

                    try
                    {
                        using (var mailClient = new SmtpClient("smtp.gmail.com"))
                        {
                            mailClient.Credentials = new NetworkCredential("ccgactiveleads", "Medixcollege1");
                            mailClient.Port = 587;

                            var message = new MailMessage();

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "MedixCollege.net");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "246")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "243")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("jlaird@medixcollege.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "242")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("kharris@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "244")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("ngauvin@medixschool.ca"));
                                message.To.Add(new MailAddress("nicole@medixschool.ca"));
                            }

                            if (fc["CampusID"].ToString() == "241")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("dickson@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "240")
                            {
                                message.To.Add(new MailAddress("toppyv@careercollegegroup.com"));
                                message.To.Add(new MailAddress("pdykstra@medixcollege.ca"));
                                message.To.Add(new MailAddress("ralary@natradeschools.ca"));
                                message.To.Add(new MailAddress("chris@medixcollege.ca"));
                            }

                            message.Subject = "New Lead - Medix - Ask a Question";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Medix" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Source");
                            data = data.Replace("ProgramID", "Program");
                            data = data.Replace("Comment2", "Comments");

                            message.Body = body + data;
                            message.IsBodyHtml = false;

                            mailClient.EnableSsl = true;
                            mailClient.Send(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Success = false;

                        ViewBag.ErrorMessage = ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> ReferralProgram(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }

        [HttpPost]
        public async Task<ActionResult> HireAGrad(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;
                }
                else
                {
                    ViewBag.Success = false;

                    ViewBag.ErrorMessage = "There was an error with your request. Please try again.";
                }

                return View("ThankYou");
            }
        }
    }
}