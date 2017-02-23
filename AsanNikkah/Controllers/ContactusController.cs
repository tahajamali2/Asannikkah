using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsanNikkah.Controllers
{
    public class ContactusController : Controller
    {
        SessionContext sescon = new SessionContext();
        // GET: Contactus
        public ActionResult Index()
        {
            return View(sescon.GetMemberData());
        }
    }
}