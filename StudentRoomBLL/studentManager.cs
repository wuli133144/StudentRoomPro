using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StudentRoom.DAL;
using StudentRoom.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace StudentRoom.BLL
{
   public  class studentManager
    {
       studentService studens = new studentService();
       public DataSet GetAllStudent()
       {
           return studens.GetAllStudent();
       }
       public SqlDataAdapter GetsqlAdp()
       {
           return studens.GetsqlAdp();
       }
       public bool DeleteStudent(student stu)
       {
          int ret= studens.DeleteStudent(stu);
          if (ret == 1)
          {
              return true;
          }
          else
              return false;


       }
       public int GetStudent(student stu)
       {
           return studens.GetStudent(stu);
       }
       /// <summary>
       /// 查询具体学生缴费
       /// </summary>
       /// <param name="fee"></param>
       /// <returns></returns>
       public bool cheackfee(student stu)
       {
           int ret = studens.cheackfee(stu);
           if (ret == 1)
           {
               return true;
           }
           else
               return false;
       }
       public DataSet getallinfo(student stu)
       {
           return studens.getallinfo(stu);
       }
    }
}
