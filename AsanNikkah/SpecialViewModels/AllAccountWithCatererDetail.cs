using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsanNikkah.SpecialViewModels
{
    public class AllAccountWithCatererDetail
    {
        public Orm_Tool.Views.All_Account All_Account { get; set; }
        public Orm_Tool.Views.Caterer Caterer { get; set; }
    }
}