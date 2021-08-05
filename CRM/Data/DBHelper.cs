using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class DBHelper
    {
        public static string ConnectionString
        {
            get
            {
                return "server=ZAEEM-UR-REHMAN; database=CRM; integrated security=True;";
                //return "server=SERVER\\MSSQLSERVERU;database=CRM;User Id=CRM;Password=CRM!!@@##;";
                //return "server=119.73.122.59;database=Cons;User Id=Construction;Password=CONS!!@@;";
            }
        }
    }
}
