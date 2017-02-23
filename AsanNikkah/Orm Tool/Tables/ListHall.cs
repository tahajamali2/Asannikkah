using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data;
using Microsoft.SqlServer.Server;

namespace AsanNikkah.Orm_Tool.Tables
{
     public class ListHall:List<Hall>,IEnumerable<SqlDataRecord>
     {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(
               new SqlMetaData("Hall_ID",SqlDbType.Int),
               new SqlMetaData("Hall_Name",SqlDbType.VarChar,-1),
               new SqlMetaData("Username",SqlDbType.VarChar,-1),
               new SqlMetaData("Password",SqlDbType.VarChar,-1),
               new SqlMetaData("Email",SqlDbType.VarChar,-1),
               new SqlMetaData("Country",SqlDbType.VarChar,-1),
               new SqlMetaData("City",SqlDbType.VarChar,-1),
               new SqlMetaData("Capacity",SqlDbType.VarChar,-1),
               new SqlMetaData("Amount",SqlDbType.VarChar,-1),
               new SqlMetaData("Type",SqlDbType.VarChar,-1),
               new SqlMetaData("Office_Contact",SqlDbType.VarChar,-1),
               new SqlMetaData("Office_Hours_From",SqlDbType.VarChar,-1),
               new SqlMetaData("Office_Hours_To",SqlDbType.VarChar,-1),
               new SqlMetaData("Website_Url",SqlDbType.VarChar,-1),
               new SqlMetaData("Facebook_Page",SqlDbType.VarChar,-1),
               new SqlMetaData("Longitude",SqlDbType.VarChar,-1),
               new SqlMetaData("Latitude",SqlDbType.VarChar,-1),
               new SqlMetaData("Img1",SqlDbType.VarChar,-1),
               new SqlMetaData("Img2",SqlDbType.VarChar,-1),
               new SqlMetaData("Img3",SqlDbType.VarChar,-1),
               new SqlMetaData("Img4",SqlDbType.VarChar,-1),
               new SqlMetaData("Img5",SqlDbType.VarChar,-1),
               new SqlMetaData("Isactive",SqlDbType.Bit),
               new SqlMetaData("IsAdminAproved",SqlDbType.Bit)
               );

            foreach (Hall data in this)
            {
                  if(CheckNullOrEmpty(data.Hall_ID))
                  {
                     ret.SetDBNull(0);
                  }

                  else 
                  {
                     ret.SetInt32(0,data.Hall_ID);
                  }


                  if(CheckNullOrEmpty(data.Hall_Name))
                  {
                     ret.SetDBNull(1);
                  }

                  else 
                  {
                     ret.SetString(1,data.Hall_Name);
                  }


                  if(CheckNullOrEmpty(data.Username))
                  {
                     ret.SetDBNull(2);
                  }

                  else 
                  {
                     ret.SetString(2,data.Username);
                  }


                  if(CheckNullOrEmpty(data.Password))
                  {
                     ret.SetDBNull(3);
                  }

                  else 
                  {
                     ret.SetString(3,data.Password);
                  }


                  if(CheckNullOrEmpty(data.Email))
                  {
                     ret.SetDBNull(4);
                  }

                  else 
                  {
                     ret.SetString(4,data.Email);
                  }


                  if(CheckNullOrEmpty(data.Country))
                  {
                     ret.SetDBNull(5);
                  }

                  else 
                  {
                     ret.SetString(5,data.Country);
                  }


                  if(CheckNullOrEmpty(data.City))
                  {
                     ret.SetDBNull(6);
                  }

                  else 
                  {
                     ret.SetString(6,data.City);
                  }


                  if(CheckNullOrEmpty(data.Capacity))
                  {
                     ret.SetDBNull(7);
                  }

                  else 
                  {
                     ret.SetString(7,data.Capacity);
                  }


                  if(CheckNullOrEmpty(data.Amount))
                  {
                     ret.SetDBNull(8);
                  }

                  else 
                  {
                     ret.SetString(8,data.Amount);
                  }


                  if(CheckNullOrEmpty(data.Type))
                  {
                     ret.SetDBNull(9);
                  }

                  else 
                  {
                     ret.SetString(9,data.Type);
                  }


                  if(CheckNullOrEmpty(data.Office_Contact))
                  {
                     ret.SetDBNull(10);
                  }

                  else 
                  {
                     ret.SetString(10,data.Office_Contact);
                  }


                  if(CheckNullOrEmpty(data.Office_Hours_From))
                  {
                     ret.SetDBNull(11);
                  }

                  else 
                  {
                     ret.SetString(11,data.Office_Hours_From);
                  }


                  if(CheckNullOrEmpty(data.Office_Hours_To))
                  {
                     ret.SetDBNull(12);
                  }

                  else 
                  {
                     ret.SetString(12,data.Office_Hours_To);
                  }


                  if(CheckNullOrEmpty(data.Website_Url))
                  {
                     ret.SetDBNull(13);
                  }

                  else 
                  {
                     ret.SetString(13,data.Website_Url);
                  }


                  if(CheckNullOrEmpty(data.Facebook_Page))
                  {
                     ret.SetDBNull(14);
                  }

                  else 
                  {
                     ret.SetString(14,data.Facebook_Page);
                  }


                  if(CheckNullOrEmpty(data.Longitude))
                  {
                     ret.SetDBNull(15);
                  }

                  else 
                  {
                     ret.SetString(15,data.Longitude);
                  }


                  if(CheckNullOrEmpty(data.Latitude))
                  {
                     ret.SetDBNull(16);
                  }

                  else 
                  {
                     ret.SetString(16,data.Latitude);
                  }


                  if(CheckNullOrEmpty(data.Img1))
                  {
                     ret.SetDBNull(17);
                  }

                  else 
                  {
                     ret.SetString(17,data.Img1);
                  }


                  if(CheckNullOrEmpty(data.Img2))
                  {
                     ret.SetDBNull(18);
                  }

                  else 
                  {
                     ret.SetString(18,data.Img2);
                  }


                  if(CheckNullOrEmpty(data.Img3))
                  {
                     ret.SetDBNull(19);
                  }

                  else 
                  {
                     ret.SetString(19,data.Img3);
                  }


                  if(CheckNullOrEmpty(data.Img4))
                  {
                     ret.SetDBNull(20);
                  }

                  else 
                  {
                     ret.SetString(20,data.Img4);
                  }


                  if(CheckNullOrEmpty(data.Img5))
                  {
                     ret.SetDBNull(21);
                  }

                  else 
                  {
                     ret.SetString(21,data.Img5);
                  }


                  if(CheckNullOrEmpty(data.Isactive))
                  {
                     ret.SetDBNull(22);
                  }

                  else 
                  {
                     ret.SetBoolean(22,(Boolean)data.Isactive);
                  }


                  if(CheckNullOrEmpty(data.IsAdminAproved))
                  {
                     ret.SetDBNull(23);
                  }

                  else 
                  {
                      ret.SetBoolean(23, (Boolean)data.IsAdminAproved);
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