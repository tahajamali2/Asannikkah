using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanNikkah.Orm_Tool.SP
{
     public static class MyProc
     {


         public static object AddEmail_Verification (AsanNikkah.Orm_Tool.Tables.ListEmail_Verification Ema_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("AddEmail_Verification_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Ema_TVP", Ema_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object UpdateEmail_Verification (AsanNikkah.Orm_Tool.Tables.ListEmail_Verification Ema_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("UpdateEmail_Verification_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Ema_TVP", Ema_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object DeleteEmail_Verification (AsanNikkah.Orm_Tool.Tables.ListEmail_Verification Ema_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("DeleteEmail_Verification_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Ema_TVP", Ema_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }



         public static object AddMember_Basic (AsanNikkah.Orm_Tool.Tables.ListMember_Basic Mem_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("AddMember_Basic_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Mem_TVP", Mem_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object UpdateMember_Basic (AsanNikkah.Orm_Tool.Tables.ListMember_Basic Mem_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("UpdateMember_Basic_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Mem_TVP", Mem_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object DeleteMember_Basic (AsanNikkah.Orm_Tool.Tables.ListMember_Basic Mem_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("DeleteMember_Basic_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Mem_TVP", Mem_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object AddHall (AsanNikkah.Orm_Tool.Tables.ListHall Hal_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("AddHall_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Hal_TVP", Hal_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object UpdateHall (AsanNikkah.Orm_Tool.Tables.ListHall Hal_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("UpdateHall_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Hal_TVP", Hal_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object DeleteHall (AsanNikkah.Orm_Tool.Tables.ListHall Hal_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("DeleteHall_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Hal_TVP", Hal_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object AddCaterer (AsanNikkah.Orm_Tool.Tables.ListCaterer Cat_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("AddCaterer_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Cat_TVP", Cat_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object UpdateCaterer (AsanNikkah.Orm_Tool.Tables.ListCaterer Cat_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("UpdateCaterer_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Cat_TVP", Cat_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object DeleteCaterer (AsanNikkah.Orm_Tool.Tables.ListCaterer Cat_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("DeleteCaterer_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Cat_TVP", Cat_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }

         public static object AddPasswordRecovery (AsanNikkah.Orm_Tool.Tables.ListPasswordRecovery Pas_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("AddPasswordRecovery_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Pas_TVP", Pas_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object UpdatePasswordRecovery (AsanNikkah.Orm_Tool.Tables.ListPasswordRecovery Pas_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("UpdatePasswordRecovery_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Pas_TVP", Pas_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object DeletePasswordRecovery (AsanNikkah.Orm_Tool.Tables.ListPasswordRecovery Pas_TVP)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("DeletePasswordRecovery_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     SqlParameter Parameter0 = Command.Parameters.AddWithValue("@Pas_TVP", Pas_TVP);
                     Parameter0.SqlDbType = System.Data.SqlDbType.Structured;
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }

         public static string GetHallLists(string Country="-1",string City="-1",int GuestCapacity=1,string Type="-1",bool IsFilter=false,int Page=1)
         {
             try
             {
                 string output = string.Empty;

                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("GetHallLists", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;

                 Command.Parameters.AddWithValue("@Country", Country);
                 Command.Parameters.AddWithValue("@City", City);
                 Command.Parameters.AddWithValue("@Capacity", GuestCapacity);
                 Command.Parameters.AddWithValue("@Type", Type);
                 Command.Parameters.AddWithValue("@Page", Page);
                 Command.Parameters.AddWithValue("@IsFilter", IsFilter);

                 SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                 DataSet ds = new DataSet();
                 Adapter.Fill(ds);

                 System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                 List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                 Dictionary<string, object> row;
                 foreach (DataRow dr in ds.Tables[0].Rows)
                 {
                     row = new Dictionary<string, object>();
                     foreach (DataColumn col in ds.Tables[0].Columns)
                     {
                         row.Add(col.ColumnName, dr[col]);
                     }
                     rows.Add(row);
                 }


                 System.Web.Script.Serialization.JavaScriptSerializer serializer2 = new System.Web.Script.Serialization.JavaScriptSerializer();
                 List<Dictionary<string, object>> rows2 = new List<Dictionary<string, object>>();
                 Dictionary<string, object> row2;
                 foreach (DataRow dr in ds.Tables[1].Rows)
                 {
                     row2 = new Dictionary<string, object>();
                     foreach (DataColumn col in ds.Tables[1].Columns)
                     {
                         row2.Add(col.ColumnName, dr[col]);
                     }
                     rows2.Add(row2);
                 }

                 output = "[" + serializer.Serialize(rows) + "," + serializer2.Serialize(rows2)+"]";

                 Adapter.Dispose();
                 Connection.Close();

                 return output;

             }

             catch (Exception ex)
             {
                 return ex.Message;
             }
         }


         public static string GetCatererLists(string Country = "-1", string City = "-1", bool IsFilter = false, int Page = 1)
         {
             try
             {
                 string output = string.Empty;

                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("GetCatererLists", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;

                 Command.Parameters.AddWithValue("@Country", Country);
                 Command.Parameters.AddWithValue("@City", City);
                 Command.Parameters.AddWithValue("@Page", Page);
                 Command.Parameters.AddWithValue("@IsFilter", IsFilter);

                 SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                 DataSet ds = new DataSet();
                 Adapter.Fill(ds);

                 System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                 List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                 Dictionary<string, object> row;
                 foreach (DataRow dr in ds.Tables[0].Rows)
                 {
                     row = new Dictionary<string, object>();
                     foreach (DataColumn col in ds.Tables[0].Columns)
                     {
                         row.Add(col.ColumnName, dr[col]);
                     }
                     rows.Add(row);
                 }


                 System.Web.Script.Serialization.JavaScriptSerializer serializer2 = new System.Web.Script.Serialization.JavaScriptSerializer();
                 List<Dictionary<string, object>> rows2 = new List<Dictionary<string, object>>();
                 Dictionary<string, object> row2;
                 foreach (DataRow dr in ds.Tables[1].Rows)
                 {
                     row2 = new Dictionary<string, object>();
                     foreach (DataColumn col in ds.Tables[1].Columns)
                     {
                         row2.Add(col.ColumnName, dr[col]);
                     }
                     rows2.Add(row2);
                 }

                 output = "[" + serializer.Serialize(rows) + "," + serializer2.Serialize(rows2) + "]";

                 Adapter.Dispose();
                 Connection.Close();

                 return output;

             }

             catch (Exception ex)
             {
                 return ex.Message;
             }
         }

         public static object AddHallRating (Decimal Rating,String Feedback,Int32 MemberId,Int32 HallId)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("AddHallRating_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     Command.Parameters.AddWithValue("@Rating",@Rating);
                     Command.Parameters.AddWithValue("@Feedback",@Feedback);
                     Command.Parameters.AddWithValue("@MemberId",@MemberId);
                     Command.Parameters.AddWithValue("@HallId", @HallId);
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


         public static object AddCatererRating (Decimal Rating,String Feedback,Int32 MemberId,Int32 CatererId)
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(AsanNikkah.Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand("AddCatererRating_SP", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        

                     Command.Parameters.AddWithValue("@Rating",@Rating);
                     Command.Parameters.AddWithValue("@Feedback",@Feedback);
                     Command.Parameters.AddWithValue("@MemberId",@MemberId);
                     Command.Parameters.AddWithValue("@CatererId", @CatererId);
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return "Operation Successfull !";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }


     }
}
