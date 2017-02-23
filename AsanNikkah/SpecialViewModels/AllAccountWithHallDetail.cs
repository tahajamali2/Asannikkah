using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsanNikkah.SpecialViewModels
{
    public class AllAccountWithHallDetail
    {
        public Orm_Tool.Views.All_Account All_Account { get; set; }
        public Orm_Tool.Views.Hall Hall { get; set; }
    }
}