using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace StudentRoom.MODEL
{
   public   class vissiter
    {
        private int adminId;

        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }
        private string adminName;

        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }
        private string adminPwd;

        public string AdminPwd
        {
            get { return adminPwd; }
            set { adminPwd = value; }
        }


    }
}
