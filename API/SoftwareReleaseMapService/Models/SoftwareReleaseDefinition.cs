
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftwareReleaseMapping.Common.Constants;

namespace SoftwareReleaseMapping.Common.Models
{
    public class SoftwareReleaseDefinition
    {
        public int SoftwareReleaseID { get; set; }
        public Nullable<short> ASystemModelYear { get; set; }
        public string ASystemGroupCode { get; set; }
        public string SoftwareReleaseCode { get; set; }
        public string SoftwareVersionNumber { get; set; }
        public string MinimumPOCClientNumber { get; set; }        
        public string SoftwareReleaseTypeName { get; set; }
        public string SoftwareReleaseNoteTypeCode { get; set; }
        public string SoftwareReleaseNoteTypeDescription { get; set; }
        public string SoftwareReleaseNoteTypeCodeLanguageLocale { get; set; }
        public int Locale { get; set; }
        public bool POCCapable { get; set; }
        public bool IsActive { get; set; }
        public List<SoftwareReleaseComponent> SoftwareReleaseComponents { get; set; }

        public DateTime LastModifiedDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string LastModifiedUserName { get; set; }
        public string RCReleaseNote { get; set; }
        public int ReleaseNoteTextId { get; set; }
        public int POCUserPermission { get; set; }
    }
}
    