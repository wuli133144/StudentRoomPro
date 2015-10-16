using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentRoom.DAL;
using StudentRoom.MODEL;

namespace StudentRoom.BLL
{
    public class vissiterManager
    {
        vissiterService viser = new vissiterService();
        public bool login_admin(vissiter viss)
        {
            return viser.login_admin(viss);
        }
    }
}
