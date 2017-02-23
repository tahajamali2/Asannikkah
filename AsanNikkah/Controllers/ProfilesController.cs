using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsanNikkah.Controllers
{
    public class ProfilesController : Controller
    {
        SessionContext sescon = new SessionContext();
        // GET: Profiles
        [AuthorizeMember]
        [OnlyMember]
        public ActionResult Index()
        {
            return View(sescon.GetMemberData());
        }
    }
}