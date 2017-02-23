using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views = AsanNikkah.Orm_Tool.Views;

namespace AsanNikkah.Controllers
{
    public class HallController : Controller
    {
        // GET: Hall
        SessionContext sescon = new SessionContext();
        AsanNikkah.SpecialViewModels.AllAccountWithHallDetail md = new SpecialViewModels.AllAccountWithHallDetail();
        public ActionResult Index(string Id)
        {
            try
            {
                if (Id != null)
                {
                    md = new SpecialViewModels.AllAccountWithHallDetail();
                    md.All_Account = sescon.GetMemberData();

                    Views.Hall.Where();
                    Views.Hall.Expression("Hall_ID=@id", new List<Tuple<string, object>>() { new Tuple<string, object>("@id", Convert.ToInt32(Id)) });

                    IList<Views.Hall> hall =  Views.Hall.Execute();

                    if (hall.Count > 0)
                    {
                        md.Hall = hall[0];
                        return View(md);
                    }

                    return RedirectToAction("Index", "Halls");
                }

                return RedirectToAction("Index", "Halls");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Halls");
            }
        }
    }
}