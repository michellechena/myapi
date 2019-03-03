using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareReleaseMapping.Common.Models
{
    public class SoftwareReleaseComponent
    {
        public int SoftwareReleaseID { get; set; }
        public string ComponentGroupCode { get; set; }
        public string ComponentNumber { get; set; }
        public bool SoftwareReleaseDerivationIndicator { get; set; }
        public string ComponentNumberSpecWeek { get; set; }
        public string LastModifiedUserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
          
    }
}
