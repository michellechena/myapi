using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareReleaseMapping.Common.Models
{
    public class SoftwareComponentNumber
    {
        public string ComponentNumber { get; set; }
        public bool IsUsedInDerivation { get; set; }
    }
}
