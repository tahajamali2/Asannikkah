using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Views
{
     public class Hall
     {
         private static string _query = "SELECT * FROM Hall_VW";
         private static List<Tuple<string,object>> paramaters = new List<Tuple<string,object>>();

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
         public Boolean Isactive { get; set; }
         public Boolean IsAdminAproved { get; set; }


         public Hall() {}

         public static void As(string keyword) 
         {
            _query += " AS " + keyword;
         }

         public static void Where() 
         {
            _query += " WHERE ";
         }

         public static void Expression(string expression,List<Tuple<string,object>> param) 
         {
            _query += expression;
            paramaters.AddRange(param);
         }

         public static void And() 
         {
            _query += " AND ";
         }

         public static void Or() 
         {
            _query += " OR ";
         }

         public static void Orderby(string[] columns) 
         {
            _query += " ORDER BY " + string.Join(",", columns);
         }

         public static void Paging(int TotalrecordPerpage , int PageNumber) 
         {
            _query += " Offset " + ((TotalrecordPerpage * PageNumber) - TotalrecordPerpage).ToString() + " ROWS FETCH NEXT "+TotalrecordPerpage+" ROWS ONLY ";
         }

         public static IList<Hall> Execute() 
         {
              SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
              List<Hall> returnHall = new List<Hall>();

                try
                {

                     Connection.Open();
                     SqlCommand Command = new SqlCommand(_query, Connection);
                     foreach (Tuple<string, object> data in paramaters)
                     {
                         Command.Parameters.AddWithValue(data.Item1, data.Item2);
                     }

                     SqlDataReader Datareader = Command.ExecuteReader();
                 
                     while (Datareader.Read())
                     {
                         returnHall.Add(new Hall()
                         {
                               Hall_ID = Datareader.GetInt32(0),

                               Hall_Name = Datareader.GetValue(1) == DBNull.Value?"":Datareader.GetString(1),

                               Username = Datareader.GetValue(2) == DBNull.Value?"":Datareader.GetString(2),

                               Password = Datareader.GetValue(3) == DBNull.Value?"":Datareader.GetString(3),

                               Email = Datareader.GetValue(4) == DBNull.Value?"":Datareader.GetString(4),

                               Country = Datareader.GetValue(5) == DBNull.Value?"":Datareader.GetString(5),

                               City = Datareader.GetValue(6) == DBNull.Value?"":Datareader.GetString(6),

                               Capacity = Datareader.GetValue(7) == DBNull.Value?"":Datareader.GetString(7),

                               Amount = Datareader.GetValue(8) == DBNull.Value?"":Datareader.GetString(8),

                               Type = Datareader.GetValue(9) == DBNull.Value?"":Datareader.GetString(9),

                               Office_Contact = Datareader.GetValue(10) == DBNull.Value?"":Datareader.GetString(10),

                               Office_Hours_From = Datareader.GetValue(11) == DBNull.Value?"":Datareader.GetString(11),

                               Office_Hours_To = Datareader.GetValue(12) == DBNull.Value?"":Datareader.GetString(12),

                               Website_Url = Datareader.GetValue(13) == DBNull.Value?"":Datareader.GetString(13),

                               Facebook_Page = Datareader.GetValue(14) == DBNull.Value?"":Datareader.GetString(14),

                               Longitude = Datareader.GetValue(15) == DBNull.Value?"":Datareader.GetString(15),

                               Latitude = Datareader.GetValue(16) == DBNull.Value?"":Datareader.GetString(16),

                               Img1 = Datareader.GetValue(17) == DBNull.Value?"":Datareader.GetString(17),

                               Img2 = Datareader.GetValue(18) == DBNull.Value?"":Datareader.GetString(18),

                               Img3 = Datareader.GetValue(19) == DBNull.Value?"":Datareader.GetString(19),

                               Img4 = Datareader.GetValue(20) == DBNull.Value?"":Datareader.GetString(20),

                               Img5 = Datareader.GetValue(21) == DBNull.Value?"":Datareader.GetString(21),

                               Isactive = Datareader.GetValue(22) == DBNull.Value ? false : Datareader.GetBoolean(22),

                               IsAdminAproved = Datareader.GetValue(23) == DBNull.Value ? false : Datareader.GetBoolean(23)
                         });
                     }
                     Datareader.Close();
                     Connection.Close();

                     paramaters.Clear();
                     _query = "SELECT * FROM Hall_VW";
                      

                }

                catch (Exception ex)
                {
                    Connection.Close();

                    paramaters.Clear();
                    _query = "SELECT * FROM Hall_VW";

                    throw new Exception(ex.Message);
                }

                    return returnHall.AsReadOnly();
         }
     }
}
