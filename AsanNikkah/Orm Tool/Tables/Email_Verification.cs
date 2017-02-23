using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Tables
{
     public class Email_Verification
     {
         public Int32 EmailVerificationID { get; set; }
         public String VerficationCode { get; set; }
         public DateTime ExpiryDate { get; set; }
         public Int32 MemberId { get; set; }
         public Boolean Isused { get; set; }
         public String ProfileType { get; set; }


         public Email_Verification() {}
     }
}
