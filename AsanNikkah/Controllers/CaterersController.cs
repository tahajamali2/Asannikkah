using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views = AsanNikkah.Orm_Tool.Views;
using Sp = AsanNikkah.Orm_Tool.SP;
using Table = AsanNikkah.Orm_Tool.Tables;
using Newtonsoft.Json.Linq;
using System.Web.Configuration;

namespace AsanNikkah.Controllers
{
    public class CaterersController : Controller
    {
        SessionContext sescon = new SessionContext();
        // GET: Caterers
        public ActionResult Index()
        {
            return View(sescon.GetMemberData());
        }

        public string GetCatererLists(string json)
        {
            try
            {
                Views.All_Account ac = sescon.GetMemberData();

                if (!json.Equals(""))
                {
                    dynamic param = JObject.Parse(json);
                    string Country = param.Country == null ? "Pakistan" : param.Country.ToString();
                    string City = param.City == null ? "Islamabad" : param.City.ToString();
                    bool IsFilter = param.IsFilter == null ? false : Convert.ToBoolean(param.IsFilter);
                    int Page = param.Page == null ? 1 : Convert.ToInt32(param.Page);

                    if (ac != null && IsFilter == false)
                    {
                        City = ac.City;
                        Country = ac.Country;
                    }

                    return Sp.MyProc.GetCatererLists(Country, City, IsFilter, Page);
                }

                return Sp.MyProc.GetCatererLists("Pakistan", "Islamabad");

            }
            catch (Exception ex)
            {
                return "[{\"Error\",\"" + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}]";
            }
        }

        [HttpPost]
        [AuthorizeMember]
        [OnlyMember]
        public string AddRating(string Rating, string comment, string CatererId)
        {
            Views.All_Account mem = sescon.GetMemberData();

            try
            {
                decimal Rating_D = Convert.ToDecimal(Rating);
                int CatererId_I = Convert.ToInt32(CatererId);

                string status = Sp.MyProc.AddCatererRating(Rating_D, comment, Convert.ToInt32(mem.ID.Split('-')[0]), CatererId_I).ToString();
                if (status.Equals("Operation Successfull !"))
                {
                    return "[{\"returntype\":\"success\",\"message\":\"Your Feedback Submitted Successfully.\"}]";
                }

                else
                {
                    return "[{\"returntype\":\"error\",\"message\":\"Some thing went wrong while processing your request.\"}]";
                }

            }
            catch (Exception ex)
            {
                return "[{\"returntype\":\"error\",\"message\":\"" + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}]";
            }
        }

        public string SendInquiry(string yourname, string youremail, string yourmessage, string catereremail)
        {
            try
            {
                string Html_Template = @"<h1>Customer Inquiry From Asannikkah.com</h1>

<br>
<p>----------------------------------------------------------</p><br>
<p><b>Customer Name</b> : " + yourname + @"</p><br>
<p><b>Email</b> : " + youremail + @"</p><br>
<p><b>Message</b> : " + yourmessage + @"</p><br>
<p>----------------------------------------------------------</p><br>
<br>
";
                string status = Email.Send(catereremail, "Customer Inquiry", Html_Template, WebConfigurationManager.AppSettings["InquiryEmailFromName"], WebConfigurationManager.AppSettings["InquiryEmailUsername"], WebConfigurationManager.AppSettings["InquiryEmailPassword"], WebConfigurationManager.AppSettings["EmailHost"], Convert.ToInt32(WebConfigurationManager.AppSettings["EmailPort"]), Convert.ToBoolean(WebConfigurationManager.AppSettings["InquiryEmailIsSSl"]));

                if (status.Equals("Sent"))
                {
                    return "[{\"returntype\":\"success\",\"message\":\"Your Inquiry Submitted Successfully.\"}]";
                }

                else
                {
                    return "[{\"returntype\":\"error\",\"message\":\"Some thing went wrong while sending your inquiry.\"}]";
                }
            }
            catch (Exception ex)
            {
                return "[{\"returntype\":\"error\",\"message\":\"Some thing went wrong while sending your inquiry.(Exception)\"}]";
            }

        }
    }
}