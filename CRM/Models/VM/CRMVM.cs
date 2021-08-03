using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models.VM
{
    public class CRMVM
    {
        public CRMDATA CRMDATA { get; set; }
        public IEnumerable<CRMDATA> CRMDATAList { get; set; }
    }
}
