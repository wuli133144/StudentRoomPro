using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentRoom.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace StudentRoom.DAL
{
    public class feeService
    {   
        /// <summary>
        /// 插入fee用
        /// </summary>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int innsertFeeStudent(fee1 fee)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.pro_insertFeestudent";
            cmd.Parameters.Add("@studentid", SqlDbType.Int).Value = fee.Studentid;
            cmd.Parameters.Add("@Feefood ", SqlDbType.Int).Value = fee.Feefood;
            cmd.Parameters.Add("@Feecon", SqlDbType.Int).Value = fee.Feeconditioner;
            cmd.Parameters.Add("@Feewarm", SqlDbType.Int).Value = fee.Feewarm;
            cmd.Parameters.Add("@Feebook", SqlDbType.Int).Value = fee.Feebook;
            cmd.Parameters.Add("@Feeroom", SqlDbType.Int).Value = fee.Feeroom;
            //返回值
            SqlParameter parret = new SqlParameter("@retvalues",SqlDbType.Int);
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
            }
            return ret;
          }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fee"></param>
        /// <returns></returns>
        public DataSet selectfeestudent(fee1 fee)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand("dbo.selectfee", con);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.Add("@studentid",SqlDbType.Int).Value=fee.Studentid;
            //返回值
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {

                adp.SelectCommand = cmd;
                adp.Fill(dt, "feestudent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           // int rettu = (int)parret.Value;
            return dt;
        }
     }
}

