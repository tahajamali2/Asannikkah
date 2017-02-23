using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.Views
{
     public class Email_Verification
     {
         private static string _query = "SELECT * FROM Email_Verification_VW";
         private static List<Tuple<string,object>> paramaters = new List<Tuple<string,object>>();

         public Int32 EmailVerificationID { get; set; }
         public String VerficationCode { get; set; }
         public DateTime ExpiryDate { get; set; }
         public Int32 MemberId { get; set; }
         public Boolean Isused { get; set; }
         public string ProfileType { get; set; }


         public Email_Verification() {}

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

         public static IList<Email_Verification> Execute() 
         {
              SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
              List<Email_Verification> returnEmail_Verification = new List<Email_Verification>();

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
                         returnEmail_Verification.Add(new Email_Verification()
                         {
                               EmailVerificationID = Datareader.GetInt32(0),

                               VerficationCode = Datareader.GetValue(1) == DBNull.Value?"":Datareader.GetString(1),

                               ExpiryDate = Datareader.GetDateTime(2),

                               MemberId = Datareader.GetInt32(3),

                               Isused = Datareader.GetValue(4) == DBNull.Value ? false : Datareader.GetBoolean(4),

                               ProfileType = Datareader.GetString(5)
                         });
                     }
                     Datareader.Close();
                     Connection.Close();

                     paramaters.Clear();
                     _query = "SELECT * FROM Email_Verification_VW";
                      

                }

                catch (Exception ex)
                {
                    Connection.Close();

                    paramaters.Clear();
                    _query = "SELECT * FROM Email_Verification_VW";

                    throw new Exception(ex.Message);
                }

                    return returnEmail_Verification.AsReadOnly();
         }
     }
}
