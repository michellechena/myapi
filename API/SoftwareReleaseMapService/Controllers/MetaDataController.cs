using Newtonsoft.Json;
using SoftwareReleaseMapping.Common;
using SoftwareReleaseMapping.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;


namespace SoftwareReleaseMapService.Controllers
{
    public class MetaDataController : ApiController
    {

        POCRCEntities _dbEntities = new POCRCEntities(); 
        public MetaDataController()
        {
        }

        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_NOTE_TYPES)]
        public HttpResponseMessage GetSoftwareReleaseNoteTypes()
        {
            HttpResponseMessage response = Request.CreateResponse();
            IEnumerable<SoftwareReleaseNoteTypes> softwareReleaseNoteTypes = new List<SoftwareReleaseNoteTypes>();
            try
            {
                //var output = "[{\"SoftwareReleaseNoteTypeCode\":\"CUST\",\"SoftwareReleaseNoteTypeDescription\":\"Customer\"},{\"SoftwareReleaseNoteTypeCode\":\"ENGR\",\"SoftwareReleaseNoteTypeDescription\":\"Engineering\"},{\"SoftwareReleaseNoteTypeCode\":\"TECH\",\"SoftwareReleaseNoteTypeDescription\":\"Technician\"}]";
                softwareReleaseNoteTypes = _dbEntities.ReleaseNoteTypes.Select(s=> new SoftwareReleaseNoteTypes {
                    SoftwareReleaseNoteTypeDescription = s.ReleaseNoteTypeDescription,
                    SoftwareReleaseNoteTypeCode = s.ReleaseNoteTypeCode
                }).ToList();
                 
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return Request.CreateResponse(HttpStatusCode.OK,softwareReleaseNoteTypes);
        }

        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_NOTE_TYPES_LANGUAGE_LOCALE)]
        public HttpResponseMessage GetSoftwareReleaseNoteTypesLanguageLocale()
        {
            //HttpResponseMessage response = Request.CreateResponse();
            List<SoftwareReleaseNoteTypesLanguageLocale> softwareReleaseNoteTypesLanguageLocale = new List<SoftwareReleaseNoteTypesLanguageLocale>();
            try
            {
                softwareReleaseNoteTypesLanguageLocale = _dbEntities.LanguageDialects.Select(s => new SoftwareReleaseNoteTypesLanguageLocale
                {
                    SoftwareReleaseNoteTypeLanguageLocaleCode = s.MicrosoftLocaleID,
                    SoftwareReleaseNoteTypeLanguageLocaleDescription = s.MicrosoftLocaleDescription
                }).ToList();
                 
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse();
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, softwareReleaseNoteTypesLanguageLocale); 
        }



    }
}
