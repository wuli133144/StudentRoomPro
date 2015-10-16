using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentRoom.MODEL;
using StudentRoom.DAL;
using System.Data;


namespace StudentRoom.BLL
{
   public  class feeManager
    {
       feeService feeser = new feeService();
       public bool innsertFeeStudent(fee1 fee)
       {
           int ret= feeser.innsertFeeStudent(fee);
           if (ret == 1)
           {
               return true;
           }
           else
               return false;
       }
         public DataSet selectfeestudent(fee1 fee)
       {
           return feeser.selectfeestudent(fee);
       }
    }
}
