using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Tables
{
     public class Member_Basic
     {
         public Int32 MemberID { get; set; }
         public String Username { get; set; }
         public String Password { get; set; }
         public String FirstName { get; set; }
         public String LastName { get; set; }
         public String Email { get; set; }
         public DateTime DOB { get; set; }
         public String Gender { get; set; }
         public String Country { get; set; }
         public String City { get; set; }
         public object Isactive { get; set; }
         public object IsAdminAproved { get; set; }


         public Member_Basic() {}
     }
}
