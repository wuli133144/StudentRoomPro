using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StudentRoom.MODEL;
using StudentRoom.DAL;

namespace StudentRoom.BLL
{
   public class parentManager
    {
       ParentService pars = new ParentService();
       public bool loinpar(parent par)
       {
           return pars.loinpar(par);
       }
    }
}
