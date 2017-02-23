using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Views
{
     public class Member_Basic
     {
         private static string _query = "SELECT * FROM Member_Basic_VW";
         private static List<Tuple<string,object>> paramaters = new List<Tuple<string,object>>();

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
         public Boolean Isactive { get; set; }
         public Boolean IsAdminAproved { get; set; }



         public Member_Basic() {}

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

         public static IList<Member_Basic> Execute() 
         {
              SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
              List<Member_Basic> returnMember_Basic = new List<Member_Basic>();

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
                         returnMember_Basic.Add(new Member_Basic()
                         {
                               MemberID = Datareader.GetInt32(0),

                               Username = Datareader.GetValue(1) == DBNull.Value?"":Datareader.GetString(1),

                               Password = Datareader.GetValue(2) == DBNull.Value?"":Datareader.GetString(2),

                               FirstName = Datareader.GetValue(3) == DBNull.Value?"":Datareader.GetString(3),

                               LastName = Datareader.GetValue(4) == DBNull.Value?"":Datareader.GetString(4),

                               Email = Datareader.GetValue(5) == DBNull.Value?"":Datareader.GetString(5),

                               DOB = Datareader.GetDateTime(6),

                               Gender = Datareader.GetValue(7) == DBNull.Value?"":Datareader.GetString(7),

                               Country = Datareader.GetValue(8) == DBNull.Value?"":Datareader.GetString(8),

                               City = Datareader.GetValue(9) == DBNull.Value?"":Datareader.GetString(9),

                               Isactive = Datareader.GetValue(10) == DBNull.Value ? false : Datareader.GetBoolean(10),

                               IsAdminAproved = Datareader.GetValue(11) == DBNull.Value ? false : Datareader.GetBoolean(11)
                         });
                     }
                     Datareader.Close();
                     Connection.Close();

                     paramaters.Clear();
                     _query = "SELECT * FROM Member_Basic_VW";
                      

                }

                catch (Exception ex)
                {
                    Connection.Close();

                    paramaters.Clear();
                    _query = "SELECT * FROM Member_Basic_VW";

                    throw new Exception(ex.Message);
                }

                    return returnMember_Basic.AsReadOnly();
         }
     }
}
