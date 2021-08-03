using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class CRMDATA
    {
        [Key]
        public int id { get; set; }
        public string Mob { get; set; }
        public string CusName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Userid { get; set; }
    }
    public class CRMDATAChild
    {
        [Key]
        public int id { get; set; }
        public string Userid { get; set; }
        public string Mob { get; set; }
        public string Remarks { get; set; }
        public DateTime DateTime { get; set; }
    }
}
