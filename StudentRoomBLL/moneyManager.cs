using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StudentRoom.MODEL;
using StudentRoom.DAL;

namespace StudentRoom.BLL
{
    public class moneyManager
    {
        moneySevice ms = new moneySevice();
        public bool login_money(Money mon)
        {
            return ms.login_money(mon); 
        }
    }
}
