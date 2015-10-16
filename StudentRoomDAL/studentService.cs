using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentRoom.MODEL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace StudentRoom.DAL
{
    public class studentService
    {
        public SqlDataAdapter adp = new SqlDataAdapter();
        /// <summary>
        /// 获取学生的信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllStudent()
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");
            DataSet dt = new DataSet();
            string Text = "SELECT * FROM student";
            SqlCommand cmd = new SqlCommand(Text,con);
            try {
           
            adp.SelectCommand = cmd;
            adp.Fill(dt,"student"); 
                }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }
        /// <summary>
        /// 获取数据适配器
        /// </summary>
        /// <returns></returns>
        public SqlDataAdapter GetsqlAdp()
        {

          return adp;

        }
        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int DeleteStudent(student stu)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");

            int ret=-1;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pro_deletestudent";
            cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = stu.StudentId;
            try
            {
                con.Open();
                ret = cmd.ExecuteNonQuery();
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
        /// 查询学生
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int GetStudent(student stu)
        {
            int ret = -1;
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");

            SqlCommand cmd =con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.pro_GetStudent";
            cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = stu.StudentId;
            SqlParameter parret = new SqlParameter("@retvalues", SqlDbType.Int);
            parret.Direction = ParameterDirection.ReturnValue;
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
        /// 是否缺勤
        /// </summary>
        /// <returns></returns>
        public int cheackfee(student stu)
        {
            int ret = -1;
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.StoredProcedure2";
            cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = stu.StudentId;
            SqlParameter parret = new SqlParameter("@retvalues", SqlDbType.Int);
            parret.Direction = ParameterDirection.ReturnValue;
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
        //////////////////////////////////////////////////////////////////////////
       public DataSet getallinfo(student stu)
        {
            SqlConnection con = new SqlConnection(@"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713");
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand("dbo.GetAllInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@studentid", SqlDbType.Int).Value = stu.StudentId;
            //返回值
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {

                adp.SelectCommand = cmd;
                adp.Fill(dt, "infostudent");
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
