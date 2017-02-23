using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace AsanNikkah.Orm_Tool
{
     class DBInfo
     {
           public static string _GetConnectionString()
           {
             return WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;
           }   
           public static string _Connectionstring =  @"Server=TJ-PC\SQLEXPRESS;Database=asannikkah;User Id=taha2;Password=hackerhero;";

     }
}