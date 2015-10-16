using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentRoom.DAL
{
    public class DBhelper
    {
        private static string strsql = @"Data Source=WIN-L8SRCUH9LF2\JACK;Initial Catalog=StudentroomDB;Persist Security Info=True;User ID=sa;pwd=720713";
       
        public static SqlConnection con = new SqlConnection(strsql);
         
    }
}
