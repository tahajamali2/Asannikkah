using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views = AsanNikkah.Orm_Tool.Views;

namespace AsanNikkah.Controllers
{
 
    public class CatererController : Controller
    {
        SessionContext sescon = new SessionContext();
        AsanNikkah.SpecialViewModels.AllAccountWithCatererDetail cd = new SpecialViewModels.AllAccountWithCatererDetail();
        // GET: Caterer
        public ActionResult Index(string Id)
        {
            try
            {
                if (Id != null)
                {
                    cd = new SpecialViewModels.AllAccountWithCatererDetail();
                    cd.All_Account = sescon.GetMemberData();

                    Views.Caterer.Where();
                    Views.Caterer.Expression("Caterer_ID=@id", new List<Tuple<string, object>>() { new Tuple<string, object>("@id", Convert.ToInt32(Id)) });

                    IList<Views.Caterer> caterer = Views.Caterer.Execute();

                    if (caterer.Count > 0)
                    {
                        cd.Caterer = caterer[0];
                        return View(cd);
                    }

                    return RedirectToAction("Index", "Caterers");
                }

                return RedirectToAction("Index", "Caterers");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Caterers");
            }
        }
    }
}