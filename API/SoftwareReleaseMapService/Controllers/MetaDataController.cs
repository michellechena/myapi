using Newtonsoft.Json;
using SoftwareReleaseMapping.Common;
using SoftwareReleaseMapping.Common.Models;
using SoftwareReleaseMapService.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using SoftwareReleaseMapService.DBModels;


namespace SoftwareReleaseMapService.Controllers
{
    public class MetaDataController : ApiController
    {

        POCRCEntities1 _dbEntities = new POCRCEntities1(); 
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

        // GET: SoftwareReleaseDefinition for a specific SoftwareReleaseID
        [HttpGet, Route(ApiConstants.POC_USER_PERMISSION + @"/{UserName}")]
        public HttpResponseMessage GetPOCUserPermissionByUserName(string UserName)
        {
            HttpResponseMessage response = Request.CreateResponse();
			SoftwareReleaseMapService.DBModels.POCUser pocUser = new SoftwareReleaseMapService.DBModels.POCUser();
            try
            {
                pocUser = (from pr in _dbEntities.POCUsers
                           join pu in _dbEntities.POCUserRoles on pr.RoleId equals pu.RoleId
                           where pr.UserName == UserName
                           select new  
                           {
                               Id = pr.Id,
                               Permission = pu.Permission,
                               UserName = pr.UserName
                           }).AsEnumerable().Select(s=> new POCUser()
                           {
                               Id = s.Id,
                               Permission = s.Permission,
                               UserName = s.UserName
                           }).FirstOrDefault();
                if (pocUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pocUser);
                }
                
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

    }
}
