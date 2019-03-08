using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareReleaseMapService.Models
{
    public class SoftwarePOCUserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int Permission { get; set; }
    }
}