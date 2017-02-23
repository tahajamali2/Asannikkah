using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AsanNikkah
{
    public class OnlyMember : AuthorizeAttribute
    {
        SessionContext sescon = new SessionContext();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            string requiredPermission = String.Format("{0}-{1}",
                   filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                   filterContext.ActionDescriptor.ActionName);


            Orm_Tool.Views.All_Account member = sescon.GetMemberData();
            if (member != null)
            {
                if (!member.ProfileType.Equals("M"))
                {

                    filterContext.Result = new RedirectToRouteResult(
                                                   new RouteValueDictionary { 
                                                { "action", "Index" }, 
                                                { "controller", "Home" } });
                }

                
            }

            else
            {
                filterContext.Result = new RedirectToRouteResult(
                                                   new RouteValueDictionary { 
                                                { "action", "Login" }, 
                                                { "controller", "Account" } });
            }

        }
    }
}