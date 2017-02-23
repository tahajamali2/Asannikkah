using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data;
using Microsoft.SqlServer.Server;

namespace AsanNikkah.Orm_Tool.Tables
{
     public class ListPasswordRecovery:List<PasswordRecovery>,IEnumerable<SqlDataRecord>
     {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
               new SqlMetaData("PasswordRecoveryID",SqlDbType.Int),
               new SqlMetaData("RecoveryCode",SqlDbType.VarChar,-1),
               new SqlMetaData("ExpiryDate",SqlDbType.DateTime),
               new SqlMetaData("MemberId",SqlDbType.Int),
               new SqlMetaData("Isused",SqlDbType.Bit),
               new SqlMetaData("ProfileType",SqlDbType.VarChar,20)
               );

            foreach (PasswordRecovery data in this)
            {
                  if(CheckNullOrEmpty(data.PasswordRecoveryID))
                  {
                     ret.SetDBNull(0);
                  }

                  else 
                  {
                     ret.SetInt32(0,data.PasswordRecoveryID);
                  }


                  if(CheckNullOrEmpty(data.RecoveryCode))
                  {
                     ret.SetDBNull(1);
                  }

                  else 
                  {
                     ret.SetString(1,data.RecoveryCode);
                  }


                  if(CheckNullOrEmpty(data.ExpiryDate))
                  {
                     ret.SetDBNull(2);
                  }

                  else 
                  {
                     ret.SetDateTime(2,data.ExpiryDate);
                  }


                  if(CheckNullOrEmpty(data.MemberId))
                  {
                     ret.SetDBNull(3);
                  }

                  else 
                  {
                     ret.SetInt32(3,data.MemberId);
                  }


                  if(CheckNullOrEmpty(data.Isused))
                  {
                     ret.SetDBNull(4);
                  }

                  else 
                  {
                     ret.SetBoolean(4,(Boolean)data.Isused);
                  }


                  if(CheckNullOrEmpty(data.ProfileType))
                  {
                     ret.SetDBNull(5);
                  }

                  else 
                  {
                     ret.SetString(5,data.ProfileType);
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