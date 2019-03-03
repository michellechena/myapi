using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareReleaseMapping.Common.Models
{
    public class SoftwareReleaseMap
    {
        public string VinLastEight { get; set; }
        public string ASystemGroupCode { get; set; }
        public string SoftwareReleaseCode { get; set; }
        public bool POCCapable { get; set; }
        public string MinimumPOCClientVersion { get; set; }
    }
}
