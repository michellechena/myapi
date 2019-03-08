using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareReleaseMapping.Common.Models
{
   public class SoftwareReleaseNote
    {
        public int SoftwareReleaseId { get; set; }
        public string Language { get; set; }
        public string ReleaseNote { get; set; }
        public string SoftwareReleaseNoteTypeCode { get; set; }        
        public string LastModifiedUserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int ReleaseNoteTextId { get; set; }

    }

}
