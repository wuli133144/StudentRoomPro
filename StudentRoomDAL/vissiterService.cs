using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentRoom.MODEL;
using System.Data;
using System.Data.SqlClient;


namespace StudentRoom.DAL
{
   public  class vissiterService
    {
      // vissiter viss = new vissiter();
       public bool login_admin(vissiter viss )
       {
             //dbo.pro_loginvisster
           SqlCommand cmd = DBhelper.con.CreateCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "dbo.pro_loginvisster";

           cmd.Parameters.Add("@adminName", SqlDbType.VarChar, 50).Value = viss.AdminName;
           cmd.Parameters.Add("@adminpwd", SqlDbType.VarChar, 15).Value = viss.AdminPwd;
           //返回值
           SqlParameter parret = new SqlParameter("@retvalues",SqlDbType.Int);
           parret.Direction = ParameterDirection.ReturnValue;
           int ret = 0;
           cmd.Parameters.Add(parret);
           try
           {
               DBhelper.con.Open();
               cmd.ExecuteNonQuery();
               ret = (int)parret.Value;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);

           }
           finally {
           DBhelper.con.Close();
           DBhelper.con.Dispose(); 
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
