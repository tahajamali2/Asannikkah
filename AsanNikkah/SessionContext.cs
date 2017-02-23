using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using Views = AsanNikkah.Orm_Tool.Views;

namespace AsanNikkah
{
    public class SessionContext
    {
        public void SetAuthenticationToken(string name, bool isPersistant, Views.All_Account empData)
        {
            string data = null;
            if (empData != null)
                data = new JavaScriptSerializer().Serialize(empData);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddYears(1), isPersistant, data);

            string cookieData = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public Views.All_Account GetMemberData()
        {
            Views.All_Account memdata = null;

            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                    memdata = new JavaScriptSerializer().Deserialize(ticket.UserData, typeof(Views.All_Account)) as Views.All_Account;
                }
            }
            catch (Exception ex)
            {
            }

            return memdata;
        }

    }
}