using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models.Raw
{
    public class RawSql
    {
       
    }
    public class Contacts
    {
        public string Contact { get; set; }
    }
    public class CRMVMQ 
    {
        public string Userid { get; set; }
        public DateTime DateTime { get; set; }
        public string Remarks { get; set; }
    }
}
