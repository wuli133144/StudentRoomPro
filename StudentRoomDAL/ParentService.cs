using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using StudentRoom.MODEL;

namespace StudentRoom.DAL
{
    public class ParentService
    {
        public bool loinpar(parent par)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.pro_loginpar";

            cmd.Parameters.Add("@parName", SqlDbType.VarChar, 50).Value = par.Name;
            cmd.Parameters.Add("@parpwd", SqlDbType.VarChar, 15).Value = par.Pwd;
            //返回值
            SqlParameter parret = new SqlParameter("@retvalues", SqlDbType.Int);
            parret.Direction = ParameterDirection.ReturnValue;
            int ret = 0;
            cmd.Parameters.Add(parret);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                ret = (int)parret.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
          
            if (ret == 1)
            {
                return true;
            }
            else
                return false;
        }

        }
    }

