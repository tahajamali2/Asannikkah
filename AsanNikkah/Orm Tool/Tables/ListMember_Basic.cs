using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data;
using Microsoft.SqlServer.Server;

namespace AsanNikkah.Orm_Tool.Tables
{
     public class ListMember_Basic:List<Member_Basic>,IEnumerable<SqlDataRecord>
     {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
               new SqlMetaData("MemberID",SqlDbType.Int),
               new SqlMetaData("Username",SqlDbType.VarChar,-1),
               new SqlMetaData("Password",SqlDbType.VarChar,-1),
               new SqlMetaData("FirstName",SqlDbType.VarChar,-1),
               new SqlMetaData("LastName",SqlDbType.VarChar,-1),
               new SqlMetaData("Email",SqlDbType.VarChar,-1),
               new SqlMetaData("DOB",SqlDbType.Date),
               new SqlMetaData("Gender",SqlDbType.VarChar,6),
               new SqlMetaData("Country",SqlDbType.VarChar,-1),
               new SqlMetaData("City",SqlDbType.VarChar,-1),
               new SqlMetaData("Isactive",SqlDbType.Bit),
               new SqlMetaData("IsAdminAproved",SqlDbType.Bit)
               );

            foreach (Member_Basic data in this)
            {
                  if(CheckNullOrEmpty(data.MemberID))
                  {
                     ret.SetDBNull(0);
                  }

                  else 
                  {
                     ret.SetInt32(0,data.MemberID);
                  }


                  if(CheckNullOrEmpty(data.Username))
                  {
                     ret.SetDBNull(1);
                  }

                  else 
                  {
                     ret.SetString(1,data.Username);
                  }


                  if(CheckNullOrEmpty(data.Password))
                  {
                     ret.SetDBNull(2);
                  }

                  else 
                  {
                     ret.SetString(2,data.Password);
                  }


                  if(CheckNullOrEmpty(data.FirstName))
                  {
                     ret.SetDBNull(3);
                  }

                  else 
                  {
                     ret.SetString(3,data.FirstName);
                  }


                  if(CheckNullOrEmpty(data.LastName))
                  {
                     ret.SetDBNull(4);
                  }

                  else 
                  {
                     ret.SetString(4,data.LastName);
                  }


                  if(CheckNullOrEmpty(data.Email))
                  {
                     ret.SetDBNull(5);
                  }

                  else 
                  {
                     ret.SetString(5,data.Email);
                  }


                  if(CheckNullOrEmpty(data.DOB))
                  {
                     ret.SetDBNull(6);
                  }

                  else 
                  {
                     ret.SetDateTime(6,data.DOB);
                  }


                  if(CheckNullOrEmpty(data.Gender))
                  {
                     ret.SetDBNull(7);
                  }

                  else 
                  {
                     ret.SetString(7,data.Gender);
                  }


                  if(CheckNullOrEmpty(data.Country))
                  {
                     ret.SetDBNull(8);
                  }

                  else 
                  {
                     ret.SetString(8,data.Country);
                  }


                  if(CheckNullOrEmpty(data.City))
                  {
                     ret.SetDBNull(9);
                  }

                  else 
                  {
                     ret.SetString(9,data.City);
                  }


                  if(CheckNullOrEmpty(data.Isactive))
                  {
                     ret.SetDBNull(10);
                  }

                  else 
                  {
                      ret.SetBoolean(10, (Boolean)data.Isactive);
                  }


                  if(CheckNullOrEmpty(data.IsAdminAproved))
                  {
                     ret.SetDBNull(11);
                  }

                  else 
                  {
                      ret.SetBoolean(11, (Boolean)data.IsAdminAproved);
                  }

                 yield return ret;
            }
        }

        private static bool CheckNullOrEmpty<T>(T value)
        {
            if (typeof(T) == typeof(string))
                return string.IsNullOrEmpty(value as string);

            return value == null || value.Equals(default(T));
        }

     }
}