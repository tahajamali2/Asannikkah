using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Views
{
     public class All_Account
     {
         private static string _query = "SELECT * FROM All_Account_VW";
         private static List<Tuple<string,object>> paramaters = new List<Tuple<string,object>>();

         public String ID { get; set; }
         public String Name { get; set; }
         public String Username { get; set; }
         public String Password { get; set; }
         public String Email { get; set; }
         public String ProfileType { get; set; }
         public Boolean IsActive { get; set; }
         public Boolean IsAdminAproved { get; set; }
         public String Img { get; set; }
         public String Country { get; set; }
         public String City { get; set; }


         public All_Account() {}

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

         public static IList<All_Account> Execute() 
         {
              SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
              List<All_Account> returnAll_Account = new List<All_Account>();

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
                         returnAll_Account.Add(new All_Account()
                         {
                               ID = Datareader.GetValue(0) == DBNull.Value?"":Datareader.GetString(0),

                               Name = Datareader.GetValue(1) == DBNull.Value?"":Datareader.GetString(1),

                               Username = Datareader.GetValue(2) == DBNull.Value?"":Datareader.GetString(2),

                               Password = Datareader.GetValue(3) == DBNull.Value?"":Datareader.GetString(3),

                               Email = Datareader.GetValue(4) == DBNull.Value?"":Datareader.GetString(4),

                               ProfileType = Datareader.GetValue(5) == DBNull.Value?"":Datareader.GetString(5),

                               IsActive = Datareader.GetValue(6) == DBNull.Value ? false : Datareader.GetBoolean(6),

                               IsAdminAproved = Datareader.GetValue(7) == DBNull.Value ? false : Datareader.GetBoolean(7),

                               Img = Datareader.GetValue(8) == DBNull.Value?"":Datareader.GetString(8),

                               Country = Datareader.GetValue(9) == DBNull.Value?"":Datareader.GetString(9),

                               City = Datareader.GetValue(10) == DBNull.Value?"":Datareader.GetString(10)
                         });
                     }
                     Datareader.Close();
                     Connection.Close();

                     paramaters.Clear();
                     _query = "SELECT * FROM All_Account_VW";
                      

                }

                catch (Exception ex)
                {
                    Connection.Close();

                    paramaters.Clear();
                    _query = "SELECT * FROM All_Account_VW";

                    throw new Exception(ex.Message);
                }

                    return returnAll_Account.AsReadOnly();
         }
     }
}
