using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Tables
{
     public class Hall
     {
         public Int32 Hall_ID { get; set; }
         public String Hall_Name { get; set; }
         public String Username { get; set; }
         public String Password { get; set; }
         public String Email { get; set; }
         public String Country { get; set; }
         public String City { get; set; }
         public String Capacity { get; set; }
         public String Amount { get; set; }
         public String Type { get; set; }
         public String Office_Contact { get; set; }
         public String Office_Hours_From { get; set; }
         public String Office_Hours_To { get; set; }
         public String Website_Url { get; set; }
         public String Facebook_Page { get; set; }
         public String Longitude { get; set; }
         public String Latitude { get; set; }
         public String Img1 { get; set; }
         public String Img2 { get; set; }
         public String Img3 { get; set; }
         public String Img4 { get; set; }
         public String Img5 { get; set; }
         public object Isactive { get; set; }
         public object IsAdminAproved { get; set; }


         public Hall() {}
     }
}
