using CRM.Models.Raw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRM.Models.VM
{
    public class CRMVM
    {
        public CRMDATA CRMDATA { get; set; }
        public CRMDATAChild CRMDATAChild { get; set; }
        public IEnumerable<CRMDATAChild> CRMDATAChildList { get; set; }
        public List<Contacts> Contacts { get; set; }
    }
}
