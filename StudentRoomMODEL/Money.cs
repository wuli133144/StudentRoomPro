using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentRoom.MODEL
{
   public class Money
    {
        private int moneyId;
        private string moneyname;
        private string moneyPwd;

        public string MoneyPwd
        {
            get { return moneyPwd; }
            set { moneyPwd = value; }
        } 
        public int MoneyId
        {
            get { return moneyId; }
            set { moneyId = value; }
        }
    

        public string Moneyname
        {
            get { return moneyname; }
            set { moneyname = value; }
        } 
       

    }
}
