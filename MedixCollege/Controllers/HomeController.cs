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
using TradesCollege.Models;

namespace MedixCollege.Controllers
{
    public class HomeController : Controller
    {
        public Dictionary<int, string> campuses = new Dictionary<int, string>();
        public Dictionary<int, string> programs = new Dictionary<int, string>();
        public Dictionary<int, string> mediaGroups = new Dictionary<int, string>();
        public Dictionary<int, string> mediaSources = new Dictionary<int, string>();

        public HomeController()
        {
            campuses.Add(24004, "Brampton-NATS");
            campuses.Add(24001, "London-NATS");
            campuses.Add(240, "Toronto");

            programs.Add(39064, "Cabinetmaking");
            programs.Add(40332, "Construction Maintenance Electrician Pre-Apprenticeship");
            programs.Add(39061, "Electrical Technology");
            programs.Add(39060, "Home Renovation Technician");
            programs.Add(39062, "HVAC Technician");
            programs.Add(40294, "Motorcycle & Small Engine Repair");
            programs.Add(39737, "Solar Energy Technician");
            programs.Add(39063, "Welding Technology");

            mediaGroups.Add(91063, "HIGH SCHOOL");
            mediaGroups.Add(90080, "INTERNET");
            mediaGroups.Add(90081, "NEWSPAPER");
            mediaGroups.Add(91092, "OUTREACH");
            mediaGroups.Add(90213, "RADIO");
            mediaGroups.Add(90083, "REFERRAL");
            mediaGroups.Add(91051, "SEARCH ENGINE MARKETING");
            mediaGroups.Add(91044, "SIGNS");
            mediaGroups.Add(91241, "SUBWAY");
            mediaGroups.Add(90082, "TELEVISION");
            mediaGroups.Add(90825, "TRADE SHOWS");
            mediaGroups.Add(90084, "VENDOR");

            mediaSources.Add(14699, "High School");
            mediaSources.Add(974, "Bing");
            mediaSources.Add(17293, "careercollegegroup.com");
            mediaSources.Add(11450, "Facebook");
            mediaSources.Add(931, "Google");
            mediaSources.Add(14173, "Kijiji");
            mediaSources.Add(18140, "Live Chat - Canada");
            mediaSources.Add(17125, "Live Chat-Baltimore");
            mediaSources.Add(1755, "London Free Press Online");
            mediaSources.Add(928, "medixcollege.ca");
            mediaSources.Add(929, "Mobile App");
            mediaSources.Add(14170, "natradeschools.ca");
            mediaSources.Add(14683, "natradeschools.edu (BALT)");
            mediaSources.Add(14698, "ncstrades.edu");
            mediaSources.Add(9026, "OntarioCollegeSearch.ca");
            mediaSources.Add(12452, "Reachlocal");
            mediaSources.Add(12451, "SEO");
            mediaSources.Add(930, "ServiceOntario.ca");
            mediaSources.Add(18289, "Text Message (Tatango)");
            mediaSources.Add(11451, "Twitter");
            mediaSources.Add(14670, "Website Student Referral Form");
            mediaSources.Add(932, "Yahoo");
            mediaSources.Add(934, "24 Hours");
            mediaSources.Add(11995, "Ajax/Pickering News Advertiser");
            mediaSources.Add(11947, "Asian Connections");
            mediaSources.Add(4982, "Brampton Guardian");
            mediaSources.Add(15794, "Brant News");
            mediaSources.Add(2030, "Brantford Expositor");
            mediaSources.Add(937, "Career Choices");
            mediaSources.Add(938, "Career Plus");
            mediaSources.Add(12132, "Downsview Mirror");
            mediaSources.Add(14682, "Employment Guide (BALT)");
            mediaSources.Add(940, "Employment News");
            mediaSources.Add(9375, "Ethnic Paper");
            mediaSources.Add(11944, "Georgetown Independent");
            mediaSources.Add(12197, "Help Wanted/Retail Pages");
            mediaSources.Add(941, "Hospital News");
            mediaSources.Add(11197, "Job Classified");
            mediaSources.Add(939, "Job Guide");
            mediaSources.Add(2029, "KW Record");
            mediaSources.Add(1754, "London Free Press");
            mediaSources.Add(2028, "Magazine/Catalogue");
            mediaSources.Add(11994, "Markham Economist and Sun");
            mediaSources.Add(933, "Metro");
            mediaSources.Add(11946, "Milton Canadian Champion");
            mediaSources.Add(11183, "Mississauga News");
            mediaSources.Add(12126, "North York Mirror");
            mediaSources.Add(11945, "Orangeville Banner");
            mediaSources.Add(1398, "Oshawa Express");
            mediaSources.Add(14681, "Penny Saver (BALT)");
            mediaSources.Add(970, "Phone Book / Other Print");
            mediaSources.Add(9376, "Pickering News Paper");
            mediaSources.Add(942, "Scarborough Mirror");
            mediaSources.Add(17497, "Taliba");
            mediaSources.Add(943, "Toronto Jobs");
            mediaSources.Add(935, "Toronto Sun");
            mediaSources.Add(1124, "Training Places");
            mediaSources.Add(17804, "Two Row Times (Native Paper)");
            mediaSources.Add(14622, "Vindicator");
            mediaSources.Add(11421, "West End Jobs");
            mediaSources.Add(14177, "Yellow Pages");
            mediaSources.Add(17718, "CanFitPRo");
            mediaSources.Add(18603, "Health & Dental Fair (Saj Mohan) March 7/15");
            mediaSources.Add(17889, "HireCanada");
            mediaSources.Add(15031, "Mall Booth");
            mediaSources.Add(15033, "National Job Fair");
            mediaSources.Add(18351, "New to Canada Supershow & Expo");
            mediaSources.Add(17890, "Newcomers Fair");
            mediaSources.Add(15032, "Service Canada Booth Lawrence Square");
            mediaSources.Add(18259, "Shoppers' World Mall Brampton Job Fair");
            mediaSources.Add(18260, "Solar Show (CANSEA)");
            mediaSources.Add(18338, "St. Joseph's High School");
            mediaSources.Add(17888, "Student Life Expo");
            mediaSources.Add(17549, "Taste of Lawrence");
            mediaSources.Add(18570, "The Toronto Jobs.ca Career Fair 2015");
            mediaSources.Add(17887, "WebTrends");
            mediaSources.Add(15175, "102.1 Edge");
            mediaSources.Add(18618, "92Q (Baltimore)");
            mediaSources.Add(18617, "98 Rock (Baltimore)");
            mediaSources.Add(17019, "Bob FM");
            mediaSources.Add(1117, "Flow 93.5 (RADIO)");
            mediaSources.Add(17671, "FM96");
            mediaSources.Add(14171, "Free FM");
            mediaSources.Add(17672, "Fresh FM 103.1");
            mediaSources.Add(2026, "KIX 106.7");
            mediaSources.Add(16644, "Myfm - St. Thomas");
            mediaSources.Add(2027, "The BEAT 91.5");
            mediaSources.Add(17552, "Virgin 99.9");
            mediaSources.Add(14669, "Y-103");
            mediaSources.Add(936, "Agency");
            mediaSources.Add(1083, "Direct Mail");
            mediaSources.Add(14924, "NATS Baltimore - Student Track Conversion");
            mediaSources.Add(17774, "Open House");
            mediaSources.Add(14390, "Past Grad");
            mediaSources.Add(14208, "PDR");
            mediaSources.Add(946, "Referral");
            mediaSources.Add(18633, "TCAF - Everest");
            mediaSources.Add(948, "Trade Show");
            mediaSources.Add(14607, "Google - Brampton");
            mediaSources.Add(14608, "Google - Brantford");
            mediaSources.Add(14609, "Google - Kitchener");
            mediaSources.Add(14605, "Google - London");
            mediaSources.Add(14610, "Google - Scarborough");
            mediaSources.Add(14606, "Google - Toronto");
            mediaSources.Add(15372, "MedixOnline.ca");
            mediaSources.Add(14960, "NATS");
            mediaSources.Add(18504, "NATS - Brampton");
            mediaSources.Add(18505, "NATS - London");
            mediaSources.Add(16959, "NATS-Google Ad Words");
            mediaSources.Add(14168, "Billboard");
            mediaSources.Add(14612, "Billboards");
            mediaSources.Add(15795, "Budweiser Gardens");
            mediaSources.Add(12283, "Bus Shelters - Astral");
            mediaSources.Add(14174, "LTC Bus");
            mediaSources.Add(16187, "Road Sign");
            mediaSources.Add(14719, "WALK IN (BALT)");
            mediaSources.Add(947, "Walk-in");
            mediaSources.Add(16177, "TTC");
            mediaSources.Add(14706, "CHCH");
            mediaSources.Add(3397, "CITY TV");
            mediaSources.Add(14685, "Comcast (BALT)");
            mediaSources.Add(14601, "COMCAST (NCST)");
            mediaSources.Add(3883, "CP24");
            mediaSources.Add(1399, "CTV");
            mediaSources.Add(1753, "CTV-2");
            mediaSources.Add(944, "Fox");
            mediaSources.Add(14684, "Fox/CW (BALT)");
            mediaSources.Add(14618, "KDKA - 2 Pitt. (NCST)");
            mediaSources.Add(14599, "MYYTV (NCST)");
            mediaSources.Add(11422, "OLN");
            mediaSources.Add(945, "Omni");
            mediaSources.Add(14172, "Rogers Television");
            mediaSources.Add(18329, "Root Sports Pitt (NCST)");
            mediaSources.Add(14600, "TIME WARNER (NCST)");
            mediaSources.Add(17208, "TLN");
            mediaSources.Add(14169, "TSN");
            mediaSources.Add(18370, "TV");
            mediaSources.Add(11203, "VIVA");
            mediaSources.Add(14686, "WBAL (BALT)");
            mediaSources.Add(14594, "WBCB-CW (NCST)");
            mediaSources.Add(14591, "WFMJ-21 (NCST)");
            mediaSources.Add(14621, "WFXP - 66 Erie (NCST)");
            mediaSources.Add(14597, "WKBN-27 (NCST)");
            mediaSources.Add(11202, "WNetwork");
            mediaSources.Add(14619, "WPXI - 11 Pitt. (NCST)");
            mediaSources.Add(14620, "WTAE - 4 Pitt. (NCST)");
            mediaSources.Add(14598, "WYFX-Fox (NCST)");
            mediaSources.Add(14595, "WYTV-33 (NCST)");
            mediaSources.Add(16169, "Local Trade Show");
            mediaSources.Add(14882, "TRADE SHOWS");
            mediaSources.Add(17798, "Western Fair");
            mediaSources.Add(956, "All Star Directories Inc.");
            mediaSources.Add(961, "Bee Line Web");
            mediaSources.Add(957, "College Bound");
            mediaSources.Add(2022, "CU Net");
            mediaSources.Add(13981, "Degree Plus");
            mediaSources.Add(2118, "EduLocator");
            mediaSources.Add(4393, "EduLocator Sub");
            mediaSources.Add(958, "EduSearch Network");
            mediaSources.Add(13977, "Grab Your Degree");
            mediaSources.Add(971, "Great Exposure PPL");
            mediaSources.Add(9156, "jack test");
            mediaSources.Add(13979, "Lightrail");
            mediaSources.Add(1962, "Natural Healers");
            mediaSources.Add(959, "PlattForm");
            mediaSources.Add(960, "Quinstreet");
            mediaSources.Add(969, "TribalFusion");
            mediaSources.Add(17298, "UC Education Marketing");
            mediaSources.Add(1080, "Vantage Media");
            mediaSources.Add(14708, "webmechanix");
        }
        public ActionResult Index()
        {
            var newsArticle = new NewsArticle();

            ViewBag.NewsArticles = newsArticle.Get().ToList();

            return View();
        }

        public ActionResult BaltimoreThankYou()
        {
            return View();
        }

        public ActionResult NewcastleThankYou()
        {
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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "NorthAmericanTradeSchools.ca");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "24004")
                            {
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "24001")
                            {

                            }

                            message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));
                            message.Bcc.Add(new MailAddress("pdykstra@medixcollege.ca"));
                            message.Bcc.Add(new MailAddress("ralary@natradeschools.ca"));

                            message.Subject = "New Lead - Trades - Apply Now";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaGroup = mediaGroups.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaID"])).Value;

                            var lead = new LeadsDTO
                            {
                                Date = DateTime.Now,
                                FirstName = fc["FirstName"],
                                LastName = fc["LastName"],
                                Email = fc["Email"],
                                Telephone = fc["Telephone"] != null ? Convert.ToInt64(fc["Telephone"]) : 0,
                                Location = campus,
                                Program = program,
                                HearAbout = mediaGroup + " - " + mediaSource,
                                Comments = fc["Comment2"]
                            };

                            var leads = new Leads();

                            leads.Insert(lead);

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaGroup ?? fc["MedaGroupID"];
                            fc["MediaID"] = mediaSource ?? fc["MediaID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Trades" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Group");
                            data = data.Replace("MediaID", "Media");
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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "NorthAmericanTradeSchools.ca");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "24004")
                            {
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "24001")
                            {

                            }

                            message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));
                            message.Bcc.Add(new MailAddress("pdykstra@medixcollege.ca"));
                            message.Bcc.Add(new MailAddress("ralary@natradeschools.ca"));

                            message.Subject = "New Lead - Trades - Book A Tour";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaGroup = mediaGroups.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaID"])).Value;

                            var lead = new LeadsDTO
                            {
                                Date = DateTime.Now,
                                FirstName = fc["FirstName"],
                                LastName = fc["LastName"],
                                Email = fc["Email"],
                                Telephone = fc["Telephone"] != null ? Convert.ToInt64(fc["Telephone"]) : 0,
                                Location = campus,
                                Program = program,
                                HearAbout = mediaGroup + " - " + mediaSource,
                                Comments = fc["Comment2"]
                            };

                            var leads = new Leads();

                            leads.Insert(lead);

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaGroup ?? fc["MediaGroupID"];
                            fc["MediaID"] = mediaSource ?? fc["MediaID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Trades" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Group");
                            data = data.Replace("MediaID", "Media");
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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "NorthAmericanTradeSchools.ca");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "24004")
                            {
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "24001")
                            {

                            }

                            message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));
                            message.Bcc.Add(new MailAddress("pdykstra@medixcollege.ca"));
                            message.Bcc.Add(new MailAddress("ralary@natradeschools.ca"));

                            message.Subject = "New Lead - Trades - Program Question";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaGroup = mediaGroups.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaID"])).Value;

                            var lead = new LeadsDTO
                            {
                                Date = DateTime.Now,
                                FirstName = fc["FirstName"],
                                LastName = fc["LastName"],
                                Email = fc["Email"],
                                Telephone = fc["Telephone"] != null ? Convert.ToInt64(fc["Telephone"]) : 0,
                                Location = campus,
                                Program = program,
                                HearAbout = mediaGroup + " - " + mediaSource,
                                Comments = fc["Comment2"]
                            };

                            var leads = new Leads();

                            leads.Insert(lead);

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaGroup ?? fc["MediaGroupID"];
                            fc["MediaID"] = mediaGroup ?? fc["MediaID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Trades" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Group");
                            data = data.Replace("MediaID", "Media");
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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "NorthAmericanTradeSchools.ca");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "24004")
                            {
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "24001")
                            {

                            }

                            message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));
                            message.Bcc.Add(new MailAddress("pdykstra@medixcollege.ca"));
                            message.Bcc.Add(new MailAddress("ralary@natradeschools.ca"));

                            message.Subject = "New Lead - Trades - Certificate Question";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaGroup = mediaGroups.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaID"])).Value;

                            var lead = new LeadsDTO
                            {
                                Date = DateTime.Now,
                                FirstName = fc["FirstName"],
                                LastName = fc["LastName"],
                                Email = fc["Email"],
                                Telephone = fc["Telephone"] != null ? Convert.ToInt64(fc["Telephone"]) : 0,
                                Location = campus,
                                Program = program,
                                HearAbout = mediaGroup + " - " + mediaSource,
                                Comments = fc["Comment2"]
                            };

                            var leads = new Leads();

                            leads.Insert(lead);

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaGroup ?? fc["MediaGroupID"];
                            fc["MediaGID"] = mediaSource ?? fc["MediaID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Trades" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Group");
                            data = data.Replace("MediaID", "Media");
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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "NorthAmericanTradeSchools.ca");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "24004")
                            {
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "24001")
                            {

                            }

                            message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));
                            message.Bcc.Add(new MailAddress("pdykstra@medixcollege.ca"));
                            message.Bcc.Add(new MailAddress("ralary@natradeschools.ca"));

                            message.Subject = "New Lead - Trades - Request Catalogue";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaGroup = mediaGroups.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaID"])).Value;

                            var lead = new LeadsDTO
                            {
                                Date = DateTime.Now,
                                FirstName = fc["FirstName"],
                                LastName = fc["LastName"],
                                Email = fc["Email"],
                                Telephone = fc["Telephone"] != null ? Convert.ToInt64(fc["Telephone"]) : 0,
                                Location = campus,
                                Program = program,
                                HearAbout = mediaGroup + " - " + mediaSource,
                                Comments = fc["Comment2"]
                            };

                            var leads = new Leads();

                            leads.Insert(lead);

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaGroup ?? fc["MediaGroupID"];
                            fc["MediaID"] = mediaSource ?? fc["MediaID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Trades" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Group");
                            data = data.Replace("MediaID", "Media");
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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "NorthAmericanTradeSchools.ca");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            if (fc["CampusID"].ToString() == "24004")
                            {
                                message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            }

                            if (fc["CampusID"].ToString() == "24001")
                            {

                            }

                            message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));
                            message.Bcc.Add(new MailAddress("pdykstra@medixcollege.ca"));
                            message.Bcc.Add(new MailAddress("ralary@natradeschools.ca"));

                            message.Subject = "New Lead - Trades - Ask a Question";

                            var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                            var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                            var mediaGroup = mediaGroups.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;
                            var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaID"])).Value;

                            var lead = new LeadsDTO
                            {
                                Date = DateTime.Now,
                                FirstName = fc["FirstName"],
                                LastName = fc["LastName"],
                                Email = fc["Email"],
                                Telephone = fc["Telephone"] != null ? Convert.ToInt64(fc["Telephone"]) : 0,
                                Location = campus,
                                Program = program,
                                HearAbout = mediaGroup + " - " + mediaSource,
                                Comments = fc["Comment2"]
                            };

                            var leads = new Leads();

                            leads.Insert(lead);

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];
                            fc["MediaID"] = mediaGroup ?? fc["MediaID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - Trades" + Environment.NewLine +
                                       Environment.NewLine;

                            var data = string.Join(",", stringArray).Replace(",", "");

                            data = data.Replace("CampusID", "Location");
                            data = data.Replace("FirstName", "First Name");
                            data = data.Replace("Lastname", "Last Name");
                            data = data.Replace("MediaGroupID", "Media Group");
                            data = data.Replace("MediaID", "Media");
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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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
            if (fc["Comment2"].Contains("www.") || fc["Comment2"].Contains("http://"))
            {
                ViewBag.Success = false;

                ViewBag.ErrorMessage = "Error submitting your request!";

                return View("ThankYou");
            }

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