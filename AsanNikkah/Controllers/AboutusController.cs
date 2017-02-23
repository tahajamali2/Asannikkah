using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsanNikkah.Controllers
{
    public class AboutusController : Controller
    {
        SessionContext sescon = new SessionContext();
        // GET: Aboutus
        public ActionResult Index()
        {
            return View(sescon.GetMemberData());
        }
    }
}