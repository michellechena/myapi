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
        public List<ComponentMap> ComponentMaps { get; set; }

    }
}
