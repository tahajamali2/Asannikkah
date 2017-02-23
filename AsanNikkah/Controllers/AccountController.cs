using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views = AsanNikkah.Orm_Tool.Views;
using Sp = AsanNikkah.Orm_Tool.SP;
using Table = AsanNikkah.Orm_Tool.Tables;
using System.Web.Configuration;
using System.IO;
using System.Net;
using System.Web.Security;

namespace AsanNikkah.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [NonAuthorizeMember]
        public ActionResult Login()
        {
            return View();
        }

        [NonAuthorizeMember]
        public ActionResult Registration()
        {
            return View();
        }

        [NonAuthorizeMember]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string Registration(string json)
        {

            List<string> exceptionlist = new List<string>();
           
            try
            {
                dynamic param = JObject.Parse(json);
                Views.All_Account.Where();
                Views.All_Account.Expression("Username=@user OR Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", param.username.ToString().Trim()), new Tuple<string, object>("@email", param.email.ToString().Trim()) });

                if (Views.All_Account.Execute().Count > 0)
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Username Or Email Already Exist. Please Try Another !\"}");
                }

                else
                {
                    string status = Sp.MyProc.AddMember_Basic(new Table.ListMember_Basic() { new Table.Member_Basic() { FirstName = param.fname.ToString(), LastName = param.lname.ToString(),
                Username=param.username.ToString(),Password=Encoding.Base64Encode(param.password.ToString()),
                Email=param.email.ToString(),DOB=Convert.ToDateTime(param.dob.ToString()),
                Gender=param.gender.ToString(),Country=param.country.ToString(),City=param.city.ToString()
                ,Isactive=false } }).ToString();

                    if (status.Equals("Operation Successfull !"))
                    {
                        Views.Member_Basic.Where();
                        Views.Member_Basic.Expression("Username=@user OR Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", param.username.ToString()), new Tuple<string, object>("@email", param.email.ToString()) });

                        IList<Views.Member_Basic> member = Views.Member_Basic.Execute();

                        string guid = Guid.NewGuid().ToString();
                        status = Sp.MyProc.AddEmail_Verification(new Table.ListEmail_Verification() { new Table.Email_Verification() { ExpiryDate = DateTime.Now.AddMinutes(10), Isused = false, MemberId = member[0].MemberID, VerficationCode = guid,ProfileType="M" } }).ToString();

                        if (status.Equals("Operation Successfull !"))
                        {
                            string Html_Template = @"<h1>Thankyou for signing up  At Asannikkah.com</h1>
<br>
<h4>Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.</h4>
<br>
<br>
<p>----------------------------------------------------------</p><br>
<p><b>Username</b> : " + member[0].Username + @"</p><br>
<p><b>Password</b> : " + Encoding.Base64Decode(member[0].Password) + @"</p><br>
<p>----------------------------------------------------------</p><br>
<br>
<h3>Please click this link to activate your account:</h3><br>
<a href='" + WebConfigurationManager.AppSettings["SiteHost"] + @"/Account/EmailVerification?Code=" + guid + @"'>Click Here</a>

";

                            status = Email.Send(member[0].Email, "Email Verification", Html_Template, WebConfigurationManager.AppSettings["EmailFromName"], WebConfigurationManager.AppSettings["EmailUsername"], WebConfigurationManager.AppSettings["EmailPassword"], WebConfigurationManager.AppSettings["EmailHost"], Convert.ToInt32(WebConfigurationManager.AppSettings["EmailPort"]), Convert.ToBoolean(WebConfigurationManager.AppSettings["EmailIsSSl"]));
                            if (status.Equals("Sent"))
                            {
                                exceptionlist.Add("{\"returntype\":\"success\",\"message\":\" You sucessfully create account in asannikkah.com\"}");
                            }

                            else
                            {
                                exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Sending Email Activation Token .Try again.\"}");
                            }
                        }

                        else
                        {
                            exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Creating Email Activation Token .Try again.\"}");
                        }

                    }

                    else
                    {
                        exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Creating Your Account .Try again.\"}");
                    }
                }

            }
            catch(Exception ex)
            {
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message+" "+ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string HallRegistration(string json)
        {
            List<string> exceptionlist = new List<string>();

            try
            {
                dynamic param = JObject.Parse(json);
                Views.All_Account.Where();
                Views.All_Account.Expression("Username=@user OR Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", param.username.ToString().Trim()), new Tuple<string, object>("@email", param.email.ToString().Trim()) });

                if (Views.All_Account.Execute().Count > 0)
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Username Or Email Already Exist. Please Try Another !\"}");
                }

                else
                {
                    string status = Sp.MyProc.AddHall(new Table.ListHall() { new Table.Hall() { Hall_Name = param.hallname.ToString(),
                Username=param.username.ToString(),Password=Encoding.Base64Encode(param.password.ToString()),
                Email=param.email.ToString(),Country=param.country.ToString(),City=param.city.ToString(),
                Capacity=param.capacity.ToString(),Amount=param.amount.ToString(),Type=param.halltype.ToString(),
                Office_Contact=param.officecontact.ToString(),Office_Hours_From=param.starthours.ToString(),
                Office_Hours_To=param.endhours.ToString(),Website_Url=param.website.ToString(),Facebook_Page=param.facebookpage.ToString(),
                Longitude=param.longitude.ToString(),Latitude=param.latitude.ToString()
                ,Isactive=false } }).ToString();


                    if (status.Equals("Operation Successfull !"))
                    {
                        Views.All_Account.Where();
                        Views.All_Account.Expression("Username=@user OR Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", param.username.ToString().Trim()), new Tuple<string, object>("@email", param.email.ToString().Trim()) });

                        IList<Views.All_Account> member = Views.All_Account.Execute();

                        string guid = Guid.NewGuid().ToString();
                        status = Sp.MyProc.AddEmail_Verification(new Table.ListEmail_Verification() { new Table.Email_Verification() { ExpiryDate = DateTime.Now.AddMinutes(10), Isused = false, MemberId = Convert.ToInt32(member[0].ID.Split('-')[0]), VerficationCode = guid, ProfileType = "H" } }).ToString();

                        if (status.Equals("Operation Successfull !"))
                        {
                            string Html_Template = @"<h1>Thankyou for signing up  At Asannikkah.com</h1>
<br>
<h4>Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.</h4>
<br>
<br>
<p>----------------------------------------------------------</p><br>
<p><b>Username</b> : " + member[0].Username + @"</p><br>
<p><b>Password</b> : " + Encoding.Base64Decode(member[0].Password) + @"</p><br>
<p>----------------------------------------------------------</p><br>
<br>
<h3>Please click this link to activate your account:</h3><br>
<a href='" + WebConfigurationManager.AppSettings["SiteHost"] + @"/Account/EmailVerification?Code=" + guid + @"'>Click Here</a>

";

                            status = Email.Send(member[0].Email, "Email Verification", Html_Template, WebConfigurationManager.AppSettings["EmailFromName"], WebConfigurationManager.AppSettings["EmailUsername"], WebConfigurationManager.AppSettings["EmailPassword"], WebConfigurationManager.AppSettings["EmailHost"], Convert.ToInt32(WebConfigurationManager.AppSettings["EmailPort"]), Convert.ToBoolean(WebConfigurationManager.AppSettings["EmailIsSSl"]));
                            if (status.Equals("Sent"))
                            {
                                exceptionlist.Add("{\"returntype\":\"success\",\"message\":\" You sucessfully create account in asannikkah.com\",\"profileid\":\"" + member[0].ID.Split('-')[0] + "\"}");
                            }

                            else
                            {
                                exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Sending Email Activation Token .Try again.\"}");
                            }
                        }

                        else
                        {
                            exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Creating Email Activation Token .Try again.\"}");
                        }

                    }

                    else
                    {
                        exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Creating Your Account .Try again.\"}");
                    }

                }


            }
            catch (Exception ex)
            {
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }


        [NonAuthorizeMember]
        [HttpPost]
        public string CatererRegistration(string json)
        {
            List<string> exceptionlist = new List<string>();

            try
            {
                dynamic param = JObject.Parse(json);
                Views.All_Account.Where();
                Views.All_Account.Expression("Username=@user OR Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", param.username.ToString().Trim()), new Tuple<string, object>("@email", param.email.ToString().Trim()) });

                if (Views.All_Account.Execute().Count > 0)
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Username Or Email Already Exist. Please Try Another !\"}");
                }

                else
                {
                    string status = Sp.MyProc.AddCaterer(new Table.ListCaterer() { new Table.Caterer() { Caterer_Name = param.caterername.ToString(),
                Username=param.username.ToString(),Password=Encoding.Base64Encode(param.password.ToString()),
                Email=param.email.ToString(),Country=param.country.ToString(),City=param.city.ToString(),
                Buffet_PH=param.rate.ToString(),
                Office_Contact=param.officecontact.ToString(),Office_Hours_From=param.starthours.ToString(),
                Office_Hours_To=param.endhours.ToString(),Website_Url=param.website.ToString(),Facebook_Page=param.facebookpage.ToString(),
                Longitude=param.longitude.ToString(),Latitude=param.latitude.ToString()
                ,Isactive=false } }).ToString();


                    if (status.Equals("Operation Successfull !"))
                    {
                        Views.All_Account.Where();
                        Views.All_Account.Expression("Username=@user OR Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", param.username.ToString().Trim()), new Tuple<string, object>("@email", param.email.ToString().Trim()) });

                        IList<Views.All_Account> member = Views.All_Account.Execute();

                        string guid = Guid.NewGuid().ToString();
                        status = Sp.MyProc.AddEmail_Verification(new Table.ListEmail_Verification() { new Table.Email_Verification() { ExpiryDate = DateTime.Now.AddMinutes(10), Isused = false, MemberId = Convert.ToInt32(member[0].ID.Split('-')[0]), VerficationCode = guid, ProfileType = "C" } }).ToString();

                        if (status.Equals("Operation Successfull !"))
                        {
                            string Html_Template = @"<h1>Thankyou for signing up  At Asannikkah.com</h1>
<br>
<h4>Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.</h4>
<br>
<br>
<p>----------------------------------------------------------</p><br>
<p><b>Username</b> : " + member[0].Username + @"</p><br>
<p><b>Password</b> : " + Encoding.Base64Decode(member[0].Password) + @"</p><br>
<p>----------------------------------------------------------</p><br>
<br>
<h3>Please click this link to activate your account:</h3><br>
<a href='" + WebConfigurationManager.AppSettings["SiteHost"] + @"/Account/EmailVerification?Code=" + guid + @"'>Click Here</a>

";

                            status = Email.Send(member[0].Email, "Email Verification", Html_Template, WebConfigurationManager.AppSettings["EmailFromName"], WebConfigurationManager.AppSettings["EmailUsername"], WebConfigurationManager.AppSettings["EmailPassword"], WebConfigurationManager.AppSettings["EmailHost"], Convert.ToInt32(WebConfigurationManager.AppSettings["EmailPort"]), Convert.ToBoolean(WebConfigurationManager.AppSettings["EmailIsSSl"]));
                            if (status.Equals("Sent"))
                            {
                                exceptionlist.Add("{\"returntype\":\"success\",\"message\":\" You sucessfully create account in asannikkah.com\",\"profileid\":\"" + member[0].ID.Split('-')[0] + "\"}");
                            }

                            else
                            {
                                exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Sending Email Activation Token .Try again.\"}");
                            }
                        }

                        else
                        {
                            exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Creating Email Activation Token .Try again.\"}");
                        }

                    }

                    else
                    {
                        exceptionlist.Add("{\"returntype\":\"error\",\"message\":\" Error Occured While Creating Your Account .Try again.\"}");
                    }

                }


            }
            catch (Exception ex)
            {
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string CheckAvailablityUsername(string username)
        {
            Views.All_Account.Where();
            Views.All_Account.Expression("Username=@user", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", username.Trim().ToLower()) });

            if (Views.All_Account.Execute().Count > 0)
            {
                return "false";
            }

            else
            {
                return "true";
            }
        }

        [HttpPost]
        public string CheckAvailablityEmail(string email)
        {
            Views.All_Account.Where();
            Views.All_Account.Expression("Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@email", email.Trim().ToLower()) });

            if (Views.All_Account.Execute().Count > 0)
            {
                return "false";
            }

            else
            {
                return "true";
            }
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string ResendEmailVerification(string username)
        {
            try
            {
                string status = string.Empty;
                Views.All_Account.Where();
                Views.All_Account.Expression("Username=@user", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", username) });

                IList<Views.All_Account> member = Views.All_Account.Execute();

                if (member.Count > 0)
                {
                    string guid = Guid.NewGuid().ToString();
                    status = Sp.MyProc.AddEmail_Verification(new Table.ListEmail_Verification() { new Table.Email_Verification() { ExpiryDate = DateTime.Now.AddMinutes(10), Isused = false, MemberId = Convert.ToInt32(member[0].ID.Split('-')[0]), VerficationCode = guid, ProfileType = member[0].ProfileType } }).ToString();

                    if (status.Equals("Operation Successfull !"))
                    {
                        string Html_Template = @"<h1>Thankyou for signing up  At Asannikkah.com</h1>
<br>
<h4>Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.</h4>
<br>
<br>
<p>----------------------------------------------------------</p><br>
<p><b>Username</b> : " + member[0].Username + @"</p><br>
<p><b>Password</b> : " + Encoding.Base64Decode(member[0].Password) + @"</p><br>
<p>----------------------------------------------------------</p><br>
<br>
<h3>Please click this link to activate your account:</h3><br>
<a href='" + WebConfigurationManager.AppSettings["SiteHost"] + @"/Account/EmailVerification?Code=" + guid + @"'>Click Here</a>

";

                        status = Email.Send(member[0].Email, "Email Verification", Html_Template, WebConfigurationManager.AppSettings["EmailFromName"], WebConfigurationManager.AppSettings["EmailUsername"], WebConfigurationManager.AppSettings["EmailPassword"], WebConfigurationManager.AppSettings["EmailHost"], Convert.ToInt32(WebConfigurationManager.AppSettings["EmailPort"]), Convert.ToBoolean(WebConfigurationManager.AppSettings["EmailIsSSl"]));

                        if (status.Equals("Sent"))
                        {
                            return "Sent";
                        }

                        return "Not Sent";
                    }

                    return "Not Sent";
                }

                else
                {
                    return "Not Sent";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [NonAuthorizeMember]
        public ActionResult EmailVerification(string Code)
        {
            try
            {
                if (!string.IsNullOrEmpty(Code))
                {
                    Views.Email_Verification.Where();
                    Views.Email_Verification.Expression("VerficationCode=@code And Isused is null", new List<Tuple<string, object>>() { new Tuple<string, object>("@code", Code) });

                    IList<Views.Email_Verification> verification = Views.Email_Verification.Execute();

                    if (verification.Count != 0)
                    {
                        string status  = Sp.MyProc.UpdateEmail_Verification(new Table.ListEmail_Verification(){new Table.Email_Verification() {EmailVerificationID=verification[0].EmailVerificationID,VerficationCode=verification[0].VerficationCode,
                        ExpiryDate=verification[0].ExpiryDate,MemberId=verification[0].MemberId,Isused=true,ProfileType=verification[0].ProfileType}}).ToString();

                        if (status.Equals("Operation Successfull !"))
                        {
                            if (verification[0].ProfileType.Equals("M"))
                            {
                                Views.Member_Basic.Where();
                                Views.Member_Basic.Expression("MemberID=@memberid", new List<Tuple<string, object>>() { new Tuple<string, object>("@memberid", verification[0].MemberId) });

                                IList<Views.Member_Basic> members = Views.Member_Basic.Execute();


                                status = Sp.MyProc.UpdateMember_Basic(new Table.ListMember_Basic() { new Table.Member_Basic() {MemberID=members[0].MemberID, FirstName = members[0].FirstName, LastName = members[0].LastName,
                Username=members[0].Username,Password=members[0].Password,
                Email=members[0].Email,DOB=members[0].DOB,
                Gender=members[0].Gender,Country=members[0].Country,City=members[0].City
                ,Isactive=true } }).ToString();
                            }

                            else if (verification[0].ProfileType.Equals("H"))
                            {
                                Views.Hall.Where();
                                Views.Hall.Expression("Hall_ID=@hallid", new List<Tuple<string, object>>() { new Tuple<string, object>("@hallid", verification[0].MemberId) });

                                IList<Views.Hall> halls = Views.Hall.Execute();

                                status = Sp.MyProc.UpdateHall(new Table.ListHall() { new Table.Hall() { Hall_ID=halls[0].Hall_ID ,Hall_Name = halls[0].Hall_Name,
                Username=halls[0].Username,Password=Encoding.Base64Encode(halls[0].Password),
                Email=halls[0].Email,Country=halls[0].Country,City=halls[0].City,
                Capacity=halls[0].Capacity,Amount=halls[0].Amount,Type=halls[0].Type,
                Office_Contact=halls[0].Office_Contact,Office_Hours_From=halls[0].Office_Hours_From,
                Office_Hours_To=halls[0].Office_Hours_To,Website_Url=halls[0].Website_Url,Facebook_Page=halls[0].Facebook_Page,
                Longitude=halls[0].Longitude,Latitude=halls[0].Latitude,Img1=halls[0].Img1,Img2=halls[0].Img2,Img3=halls[0].Img3,Img4=halls[0].Img4,Img5=halls[0].Img5
                ,Isactive=true } }).ToString();

                            }

                            else if (verification[0].ProfileType.Equals("C"))
                            {
                                Views.Caterer.Where();
                                Views.Caterer.Expression("Caterer_ID=@catererid", new List<Tuple<string, object>>() { new Tuple<string, object>("@catererid", verification[0].MemberId) });

                                IList<Views.Caterer> caterers = Views.Caterer.Execute();

                                status = Sp.MyProc.UpdateCaterer(new Table.ListCaterer() { new Table.Caterer() { Caterer_ID=caterers[0].Caterer_ID ,Caterer_Name = caterers[0].Caterer_Name,
                Username=caterers[0].Username,Password=Encoding.Base64Encode(caterers[0].Password),
                Email=caterers[0].Email,Country=caterers[0].Country,City=caterers[0].City,
                Buffet_PH=caterers[0].Buffet_PH,
                Office_Contact=caterers[0].Office_Contact,Office_Hours_From=caterers[0].Office_Hours_From,
                Office_Hours_To=caterers[0].Office_Hours_To,Website_Url=caterers[0].Website_Url,Facebook_Page=caterers[0].Facebook_Page,
                Longitude=caterers[0].Longitude,Latitude=caterers[0].Latitude,Img1=caterers[0].Img1,Img2=caterers[0].Img2,Img3=caterers[0].Img3,Img4=caterers[0].Img4,Img5=caterers[0].Img5
                ,Isactive=true } }).ToString();
                            }

                            if (status.Equals("Operation Successfull !"))
                            {
                                ViewBag.status = "Updated";
                                return View();
                            }

                            ViewBag.status = "Member Not Updated";
                            return View();
                        }

                        ViewBag.status = "Email Verification Not Updated";
                        return View();

                    }

                    return RedirectToAction("Login", "Account");
                }

                return RedirectToAction("Login", "Account");
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string UploadFileHall(string id)
        {
            List<string> exceptionlist = new List<string>();
            
            try
            {
                string guid = string.Empty;
                List<string> imgs = new List<string>();
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var ext = Path.GetExtension(fileContent.FileName);
                        guid = Guid.NewGuid().ToString();

                        imgs.Add(guid + ext);
                        var path = Path.Combine(Server.MapPath("~/Content/UploadedData/HallImages"), guid+ext);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }

                imgs.Add("");
                imgs.Add("");
                imgs.Add("");
                imgs.Add("");

                Views.Hall.Where();
                Views.Hall.Expression("Hall_ID=@hallid", new List<Tuple<string, object>>() { new Tuple<string, object>("@hallid", id) });

                IList<Views.Hall> halls = Views.Hall.Execute();

                string status = Sp.MyProc.UpdateHall(new Table.ListHall() { new Table.Hall() { Hall_ID=halls[0].Hall_ID ,Hall_Name = halls[0].Hall_Name,
                Username=halls[0].Username,Password=halls[0].Password,
                Email=halls[0].Email,Country=halls[0].Country,City=halls[0].City,
                Capacity=halls[0].Capacity,Amount=halls[0].Amount,Type=halls[0].Type,
                Office_Contact=halls[0].Office_Contact,Office_Hours_From=halls[0].Office_Hours_From,
                Office_Hours_To=halls[0].Office_Hours_To,Website_Url=halls[0].Website_Url,Facebook_Page=halls[0].Facebook_Page,
                Longitude=halls[0].Longitude,Latitude=halls[0].Latitude,Img1=imgs[0],Img2=imgs[1],Img3=imgs[2],Img4=imgs[3],Img5=imgs[4]
                ,Isactive=false } }).ToString();

                if (status.Equals("Operation Successfull !"))
                {
                    exceptionlist.Add("{\"returntype\":\"success\",\"message\":\" You sucessfully create account in asannikkah.com\"}");
                }

                else
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Updating Images Info.\"}");
                }
               
            }
            catch (Exception ex)
            {
                //Response.StatusCode = (int)HttpStatusCode.BadRequest;
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }


        [NonAuthorizeMember]
        [HttpPost]
        public string UploadFileCaterer(string id)
        {
            List<string> exceptionlist = new List<string>();

            try
            {
                string guid = string.Empty;
                List<string> imgs = new List<string>();
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var ext = Path.GetExtension(fileContent.FileName);
                        guid = Guid.NewGuid().ToString();

                        imgs.Add(guid + ext);
                        var path = Path.Combine(Server.MapPath("~/Content/UploadedData/CatererImages"), guid + ext);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }

                imgs.Add("");
                imgs.Add("");
                imgs.Add("");
                imgs.Add("");

                Views.Caterer.Where();
                Views.Caterer.Expression("Caterer_ID=@catererid", new List<Tuple<string, object>>() { new Tuple<string, object>("@catererid", id) });

                IList<Views.Caterer> caterers = Views.Caterer.Execute();

                string status = Sp.MyProc.UpdateCaterer(new Table.ListCaterer() { new Table.Caterer() { Caterer_ID=caterers[0].Caterer_ID ,Caterer_Name = caterers[0].Caterer_Name,
                Username=caterers[0].Username,Password=caterers[0].Password,
                Email=caterers[0].Email,Country=caterers[0].Country,City=caterers[0].City,
                Buffet_PH=caterers[0].Buffet_PH,
                Office_Contact=caterers[0].Office_Contact,Office_Hours_From=caterers[0].Office_Hours_From,
                Office_Hours_To=caterers[0].Office_Hours_To,Website_Url=caterers[0].Website_Url,Facebook_Page=caterers[0].Facebook_Page,
                Longitude=caterers[0].Longitude,Latitude=caterers[0].Latitude,Img1=imgs[0],Img2=imgs[1],Img3=imgs[2],Img4=imgs[3],Img5=imgs[4]
                ,Isactive=false } }).ToString();

                if (status.Equals("Operation Successfull !"))
                {
                    exceptionlist.Add("{\"returntype\":\"success\",\"message\":\" You sucessfully create account in asannikkah.com\"}");
                }

                else
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Updating Images Info.\"}");
                }

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string ForgetPassword(string usernameoremail)
        {
            List<string> exceptionlist = new List<string>();
            try 
            {
                Views.All_Account.Where();
                Views.All_Account.Expression("Username=@user or Email=@email", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", usernameoremail),new Tuple<string, object>("@email", usernameoremail) });

                IList<Views.All_Account> account = Views.All_Account.Execute();

                if (account.Count > 0)
                {
                    string guid = Guid.NewGuid().ToString();
                    string status = Sp.MyProc.AddPasswordRecovery(new Table.ListPasswordRecovery(){new Table.PasswordRecovery(){
                        RecoveryCode=guid,
                        ExpiryDate = DateTime.Now.AddMinutes(10),
                        MemberId = Convert.ToInt32(account[0].ID.Split('-')[0]),
                        Isused=false,
                        ProfileType=account[0].ProfileType
                    }}).ToString();

                    if (status.Equals("Operation Successfull !"))
                    {
                        string Html_Template = @"<h1>Password Recovery Request  At Asannikkah.com</h1>
<br>
<h4>Your account has been request password recovery, you can click on the link below provided in this email to reset your password.</h4>
<br>
<br>
<br>
<h3>Please click this link to reset your password:</h3><br>
<a href='" + WebConfigurationManager.AppSettings["SiteHost"] + @"/Account/PasswordReset?RecoveryCode=" + guid + @"'>Click Here</a>

";

                        status = Email.Send(account[0].Email, "Password Reset", Html_Template, "Password Reset", WebConfigurationManager.AppSettings["EmailUsername"], WebConfigurationManager.AppSettings["EmailPassword"], WebConfigurationManager.AppSettings["EmailHost"], Convert.ToInt32(WebConfigurationManager.AppSettings["EmailPort"]), Convert.ToBoolean(WebConfigurationManager.AppSettings["EmailIsSSl"]));

                        if (status.Equals("Sent"))
                        {
                            exceptionlist.Add("{\"returntype\":\"success\",\"message\":\"Password Recovery Link Is Successfully Sent To Your Email.\"}");
                        }

                        else
                        {
                            exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Sending Recovery Link To The Email !.\"}");
                        }
                    }

                    else
                    {
                        exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Adding Recovery Record To Database !.\"}");
                    }
                }

                else
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Account Does Not Exist !.\"}");
                }
            }
            catch (Exception ex)
            {
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }

        [NonAuthorizeMember]
        public ActionResult PasswordReset(string RecoveryCode)
        {

            try
            {
                Views.PasswordRecovery.Where();
                Views.PasswordRecovery.Expression("RecoveryCode=@code and (Isused is null or Isused=0)", new List<Tuple<string, object>>() { new Tuple<string, object>("@code", RecoveryCode) });

                IList<Views.PasswordRecovery> recovery = Views.PasswordRecovery.Execute();

                if (recovery.Count > 0)
                {
                    return View();
                }

                else
                {
                    return RedirectToAction("Login", "Account");
                }

            }

            catch (Exception ex)
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string PasswordReset(string newpassword,string confirmpassword,string code)
        { 
            List<string> exceptionlist = new List<string>();
            string status = string.Empty;

            try
            {
                Views.PasswordRecovery.Where();
                Views.PasswordRecovery.Expression("RecoveryCode=@code and (Isused is null or Isused=0)", new List<Tuple<string, object>>() { new Tuple<string, object>("@code", code) });

                IList<Views.PasswordRecovery> recovery = Views.PasswordRecovery.Execute();

                if (recovery.Count > 0)
                {
                    status = Sp.MyProc.UpdatePasswordRecovery(new Table.ListPasswordRecovery(){new Table.PasswordRecovery() {
                            PasswordRecoveryID=recovery[0].PasswordRecoveryID,
                            RecoveryCode=recovery[0].RecoveryCode,
                            ExpiryDate=recovery[0].ExpiryDate,
                            MemberId=recovery[0].MemberId,
                            Isused=true,
                            ProfileType=recovery[0].ProfileType,
                        }}).ToString();

                    if (status.Equals("Operation Successfull !"))
                    {
                        if (recovery[0].ProfileType.Equals("M"))
                        {
                            Views.Member_Basic.Where();
                            Views.Member_Basic.Expression("MemberID=@id", new List<Tuple<string, object>>() { new Tuple<string, object>("@id", recovery[0].MemberId) });

                            IList<Views.Member_Basic> member = Views.Member_Basic.Execute();

                            status = Sp.MyProc.UpdateMember_Basic(new Table.ListMember_Basic() {new Table.Member_Basic() {
                                MemberID=member[0].MemberID,
                                Username=member[0].Username,
                                Password=Encoding.Base64Encode(newpassword),
                                FirstName = member[0].FirstName,
                                LastName = member[0].LastName,
                                Email = member[0].Email,
                                DOB = member[0].DOB,
                                Gender = member[0].Gender,
                                Country = member[0].Country,
                                City = member[0].City,
                                Isactive = member[0].Isactive,
                                IsAdminAproved = member[0].IsAdminAproved
                            }}).ToString();

                            if (status.Equals("Operation Successfull !"))
                            {
                                exceptionlist.Add("{\"returntype\":\"success\",\"message\":\"Password Reset Successfully .\"}");
                            }

                            else
                            {
                                exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Updating New Password !.\"}");
                            }
                        }

                        else if (recovery[0].ProfileType.Equals("H"))
                        {

                            Views.Hall.Where();
                            Views.Hall.Expression("Hall_ID=@id", new List<Tuple<string, object>>() { new Tuple<string, object>("@id", recovery[0].MemberId) });

                            IList<Views.Hall> halls = Views.Hall.Execute();

                            status = Sp.MyProc.UpdateHall(new Table.ListHall() { new Table.Hall() { Hall_ID=halls[0].Hall_ID ,Hall_Name = halls[0].Hall_Name,
                Username=halls[0].Username,Password=Encoding.Base64Encode(newpassword),
                Email=halls[0].Email,Country=halls[0].Country,City=halls[0].City,
                Capacity=halls[0].Capacity,Amount=halls[0].Amount,Type=halls[0].Type,
                Office_Contact=halls[0].Office_Contact,Office_Hours_From=halls[0].Office_Hours_From,
                Office_Hours_To=halls[0].Office_Hours_To,Website_Url=halls[0].Website_Url,Facebook_Page=halls[0].Facebook_Page,
                Longitude=halls[0].Longitude,Latitude=halls[0].Latitude,Img1=halls[0].Img1,Img2=halls[0].Img2,Img3=halls[0].Img3,Img4=halls[0].Img4,Img5=halls[0].Img5
                ,Isactive=halls[0].Isactive } }).ToString();

                            if (status.Equals("Operation Successfull !"))
                            {
                                exceptionlist.Add("{\"returntype\":\"success\",\"message\":\"Password Reset Successfully .\"}");
                            }

                            else
                            {
                                exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Updating New Password !.\"}");
                            }

                        }

                        else if (recovery[0].ProfileType.Equals("C"))
                        {
                            Views.Caterer.Where();
                            Views.Caterer.Expression("Caterer_ID=@id", new List<Tuple<string, object>>() { new Tuple<string, object>("@id", recovery[0].MemberId) });

                            IList<Views.Caterer> caterers = Views.Caterer.Execute();

                            status = Sp.MyProc.UpdateCaterer(new Table.ListCaterer() { new Table.Caterer() { Caterer_ID=caterers[0].Caterer_ID ,Caterer_Name = caterers[0].Caterer_Name,
                Username=caterers[0].Username,Password=Encoding.Base64Encode(newpassword),
                Email=caterers[0].Email,Country=caterers[0].Country,City=caterers[0].City,
                Buffet_PH=caterers[0].Buffet_PH,
                Office_Contact=caterers[0].Office_Contact,Office_Hours_From=caterers[0].Office_Hours_From,
                Office_Hours_To=caterers[0].Office_Hours_To,Website_Url=caterers[0].Website_Url,Facebook_Page=caterers[0].Facebook_Page,
                Longitude=caterers[0].Longitude,Latitude=caterers[0].Latitude,Img1=caterers[0].Img1,Img2=caterers[0].Img2,Img3=caterers[0].Img3,Img4=caterers[0].Img4,Img5=caterers[0].Img5
                ,Isactive=caterers[0].Isactive } }).ToString();

                            if (status.Equals("Operation Successfull !"))
                            {
                                exceptionlist.Add("{\"returntype\":\"success\",\"message\":\"Password Reset Successfully .\"}");
                            }

                            else
                            {
                                exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Updating New Password !.\"}");
                            }
                        }
                    }

                    else
                    {
                        exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Error Occured When Updating Password Reset Token !.\"}");
                    }
                }

                else
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Password Reset Code Does Not Exist !.\"}");
                }
            }
            catch (Exception ex)
            {
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }

        [NonAuthorizeMember]
        [HttpPost]
        public string Login(string json)
        {
            List<string> exceptionlist = new List<string>();

            try
            {
                SessionContext sescontext = new SessionContext();
                dynamic param = JObject.Parse(json);
                string usernameoremail = param.usernameoremail.ToString().ToLower().Trim();
                string password = param.password.ToString();
                bool rememberme = param.isforget == null ? false : true;

                Views.All_Account.Where();
                Views.All_Account.Expression("(Username=@user or Email=@email) AND Password=@pass", new List<Tuple<string, object>>() { new Tuple<string, object>("@user", usernameoremail), new Tuple<string, object>("@email", usernameoremail), new Tuple<string, object>("@pass", Encoding.Base64Encode(password)) });

                IList<Views.All_Account> a = Views.All_Account.Execute();

                if (a.Count > 0)
                {
                    if (a[0].IsActive)
                    {

                        if (a[0].IsAdminAproved)
                        {
                            sescontext.SetAuthenticationToken(a[0].ID, rememberme, a[0]);
                            exceptionlist.Add("{\"returntype\":\"success\",\"message\":\"You Are Now Redirecting To Homepage.\"}");
                        }

                        else
                        {
                            exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Sorry ! Your Account Is Not Approved By Admin.\"}");
                        }
                    }

                    else
                    {
                        exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Sorry ! Your Account Is Not Active.\"}");
                    }
                }

                else
                {
                    exceptionlist.Add("{\"returntype\":\"error\",\"message\":\"Sorry ! Username Or Password Is Incorrect.\"}");
                }

            }
            catch (Exception ex)
            {
                exceptionlist.Add("{\"returntype\":\"errorexception\",\"message\":\" " + HttpUtility.JavaScriptStringEncode(ex.Message + " " + ex.StackTrace) + "\"}");
            }

            return "[" + string.Join(",", exceptionlist) + "]";
        }

        [AuthorizeMember]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}