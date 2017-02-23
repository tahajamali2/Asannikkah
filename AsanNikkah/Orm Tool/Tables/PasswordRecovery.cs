using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Tables
{
     public class PasswordRecovery
     {
         public Int32 PasswordRecoveryID { get; set; }
         public String RecoveryCode { get; set; }
         public DateTime ExpiryDate { get; set; }
         public Int32 MemberId { get; set; }
         public object Isused { get; set; }
         public String ProfileType { get; set; }


         public PasswordRecovery() {}
     }
}
