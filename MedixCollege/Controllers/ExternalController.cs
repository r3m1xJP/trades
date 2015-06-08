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
    public class ExternalController : Controller
    {
        public Dictionary<int, string> campuses = new Dictionary<int, string>();
        public Dictionary<int, string> programs = new Dictionary<int, string>();
        public Dictionary<int, string> mediaSources = new Dictionary<int, string>();

        public ExternalController()
        {
            campuses.Add(24002, "Baltimore");
            campuses.Add(24003, "Newcastle");

            programs.Add(39119, "Building Construction Technology");
            programs.Add(39120, "Commercial Truck Driving");
            programs.Add(39121, "Diesel Technician");
            programs.Add(39061, "Electrical Technology");
            programs.Add(30123, "HRVAC Technology");
            programs.Add(39125, "Industrial Maintenance");
            programs.Add(39129, "Combination Welding");
            programs.Add(40235, "Motorcycle and Power Equipment Technology");

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

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult PPC()
        {
            return View();
        }

        public ActionResult PPCNoDropDown()
        {
            return View();
        }

        public ActionResult ReferAFriend()
        {
            return View();
        }

        public ActionResult RequestInformation()
        {
            return View();
        }

        public ActionResult ContactUsMobile()
        {
            return View();
        }

        public ActionResult QuickContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ExternalPost(FormCollection fc)
        {
            var formData = new FormUrlEncodedContent(fc.AllKeys.ToDictionary(k => k, v => fc[v]));

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://www1.campuslogin.com/Contacts/Web/ImportContactData.aspx", formData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = true;

                    var campus = campuses.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["CampusID"])).Value;
                    var program = programs.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["ProgramID"])).Value;
                    var mediaSource = mediaSources.FirstOrDefault(x => x.Key == Convert.ToInt32(fc["MediaGroupID"])).Value;

                    var lead = new LeadsDTO
                    {
                        Date = DateTime.Now,
                        FirstName = fc["FirstName"],
                        LastName = fc["LastName"],
                        Email = fc["Email"],
                        Telephone = fc["Telephone"] != null ? Convert.ToInt64(fc["Telephone"]) : 0,
                        Location = campus,
                        Program = program,
                        HearAbout = mediaSource,
                        Comments = fc["Comment2"]
                    };

                    var leads = new Leads();

                    leads.Insert(lead);

                    try
                    {
                        using (var mailClient = new SmtpClient("smtp.gmail.com"))
                        {
                            mailClient.Credentials = new NetworkCredential("ccgactiveleads", "Medixcollege1");
                            mailClient.Port = 587;

                            var message = new MailMessage();

                            message.From = new MailAddress("ccgactiveleads@gmail.com", "MedixCollege.net");

                            message.To.Add(new MailAddress("activeleads@medixcollege.ca"));

                            //if (fc["CampusID"].ToString() == "246")
                            //{
                            //    message.To.Add(new MailAddress("cbrandt@medixcollege.ca"));
                            //}

                            message.Bcc.Add(new MailAddress("toppyv@careercollegegroup.com"));

                            message.Subject = "New Lead - External";

                            fc["CampusID"] = campus ?? fc["CampusID"];
                            fc["ProgramID"] = program ?? fc["ProgramID"];
                            fc["MediaGroupID"] = mediaSource ?? fc["MediaGroupID"];

                            var stringArray = (from key in fc.AllKeys
                                               from value in fc.GetValues(key)
                                               where key != "ORGID" && key != "MailListID"
                                               select string.Format("{0}: {1}" + Environment.NewLine, HttpUtility.UrlEncode(key), value)).ToArray();

                            var body = "New Lead - External" + Environment.NewLine +
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
                            //mailClient.Send(message);
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
            }

            return View("ThankYou");
        }
    }
}