using SoftwareReleaseMapping.Common.Models;
//using SoftwareReleaseMapping.Services;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using SoftwareReleaseMapping.Common;

using System.Data.Entity;

namespace SoftwareReleaseMapService.Controllers
{
    public class SoftwareReleaseDefinitionController : ApiController
    {
        POCRCEntities _dbEntities = new POCRCEntities();
        public SoftwareReleaseDefinitionController()
        {
        }
        // GET: SoftwareReleaseDefinition
        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_DEFINITIONS)]
        public HttpResponseMessage GetSoftwareReleaseDefinitions()
        {
            HttpResponseMessage response = Request.CreateResponse();
            IEnumerable<SoftwareReleaseDefinition> softwareReleaseDefinitions = new List<SoftwareReleaseDefinition>();
            
            try
            {
                softwareReleaseDefinitions = (from r in _dbEntities.Releases
                                              select new
                                              {
                                                  SoftwareReleaseID = r.ReleaseID,
                                                  ASystemModelYear = r.ModelYear,
                                                  ASystemGroupCode = r.SystemGroupCode,
                                                  SoftwareReleaseCode = r.ReleaseCode,
                                                  SoftwareVersionNumber = r.VersionNumber,
                                                  MinimumPOCClientNumber = r.MinimumConnectClientVersion,
                                                  ReleaseTypeId = r.ReleaseTypeID,
                                                  POCCapable = r.ConnectCapableIndicator,
                                                  IsActive = r.ActiveIndicator, 
                                                  LastModifiedUserName = r.LastModifiedUserName,
                                                  LastModifiedDateTime = r.LastModifiedDateTime,
                                                  CreateDateTime = r.CreatedDateTime
                                                  
                                              }).AsEnumerable().Select(s => new SoftwareReleaseDefinition
                                              {
                                                  SoftwareReleaseID = s.SoftwareReleaseID,
                                                  ASystemModelYear = s.ASystemModelYear,
                                                  ASystemGroupCode = s.ASystemGroupCode,
                                                  SoftwareReleaseCode = s.SoftwareReleaseCode,
                                                  SoftwareVersionNumber = s.SoftwareVersionNumber,
                                                  MinimumPOCClientNumber = s.MinimumPOCClientNumber,
                                                  SoftwareReleaseTypeName = Convert.ToString(s.ReleaseTypeId),
                                                  POCCapable = s.POCCapable,
                                                  IsActive = s.IsActive,
                                                  CreationDateTime = s.CreateDateTime,
                                                  LastModifiedDateTime = s.LastModifiedDateTime,
                                                  LastModifiedUserName = s.LastModifiedUserName
                                              }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, softwareReleaseDefinitions);
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        // GET: SoftwareReleaseDefinition for a specific SoftwareReleaseID
        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_DEFINITIONS + @"/{SoftwareReleaseID}")]
        public HttpResponseMessage GetSoftwareReleaseDefinitionsBySoftwareReleaseID(int SoftwareReleaseID)
        {
            HttpResponseMessage response = Request.CreateResponse();
            SoftwareReleaseDefinition softwareReleaseDefinition = new SoftwareReleaseDefinition();
            //IEnumerable<KeyValuePair<string, string>> queryStringData = Request.GetQueryNameValuePairs();
            try
            {
                //var output = "[{\"SoftwareReleaseID\":260,\"ASystemModelYear\":\"2020\",\"ASystemGroupCode\":\"EMS\",\"SoftwareReleaseCode\":\"AA13_BB2017_CC57\",\"SoftwareVersionNumber\":\"3.5\",\"MinimumPOCClientNumber\":\"333\",\"SoftwareReleaseTypeName\":\"Mandatory\",\"SoftwareReleaseNoteTypeCode\":null,\"SoftwareReleaseNoteTypeDescription\":null,\"Locale\":null,\"POCCapable\":true,\"IsActive\":true,\"SoftwareReleaseComponents\":[{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1269\",\"ComponentNumber\":\"44444\",\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1274\",\"ComponentNumber\":\"444\",\"SoftwareReleaseDerivationIndicator\":true,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"}],\"LastModifiedDateTime\":\"2019-02-20T01:34:13.913\",\"CreationDateTime\":\"2019-02-20T01:34:13.913\",\"LastModifiedUserName\":\"Test\"}]";
                softwareReleaseDefinition = (from r in _dbEntities.Releases
                                             join rn in _dbEntities.ReleaseNotes on r.ReleaseID equals rn.ReleaseID
                                             join  dt in _dbEntities.DialectTexts on rn.ReleaseNoteTextID equals dt.TextID
                                              where r.ReleaseID ==SoftwareReleaseID
                                              select new
                                              {
                                                  SoftwareReleaseID = r.ReleaseID,
                                                  ASystemModelYear = r.ModelYear,
                                                  ASystemGroupCode = r.SystemGroupCode,
                                                  SoftwareReleaseCode = r.ReleaseCode,
                                                  SoftwareVersionNumber = r.VersionNumber,
                                                  MinimumPOCClientNumber = r.MinimumConnectClientVersion,
                                                  ReleaseTypeId = r.ReleaseTypeID,
                                                  POCCapable = r.ConnectCapableIndicator,
                                                  IsActive  =r.ActiveIndicator,
                                                  ReleaseNoteTypeCode = rn.ReleaseNoteTypeCode,
                                                  MicroSoftLocaleID = dt.MicrosoftLocaleID,
                                                  RCReleaseNote = dt.LanguageText
                                              }).AsEnumerable().Select(s=> new SoftwareReleaseDefinition
                                              {
                                                  SoftwareReleaseID = s.SoftwareReleaseID,
                                                  ASystemModelYear = s.ASystemModelYear,
                                                  ASystemGroupCode = s.ASystemGroupCode,
                                                  SoftwareReleaseCode = s.SoftwareReleaseCode,
                                                  SoftwareVersionNumber = s.SoftwareVersionNumber,
                                                  MinimumPOCClientNumber = s.MinimumPOCClientNumber,
                                                  SoftwareReleaseTypeName = Convert.ToString(s.ReleaseTypeId),
                                                  POCCapable = s.POCCapable,
                                                  IsActive = s.IsActive,
                                                  SoftwareReleaseNoteTypeCode = s.ReleaseNoteTypeCode,
                                                  SoftwareReleaseNoteTypeCodeLanguageLocale = Convert.ToString(s.MicroSoftLocaleID),
                                                  SoftwareReleaseNoteTypeDescription = Convert.ToString(s.MicroSoftLocaleID),
                                                  RCReleaseNote = s.RCReleaseNote
                                              }).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, softwareReleaseDefinition);
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        // POST: SoftwareReleaseDefinition for a specific SoftwareReleaseID
        [HttpPost, Route(ApiConstants.SOFTWARE_RELEASE_DEFINITIONS)]
        public HttpResponseMessage AddSoftwareReleaseComponents(SoftwareReleaseDefinition softwareReleaseDefinition)
        {
            
            HttpResponseMessage response = Request.CreateResponse();
             
            try
            {
                int nextReleaseID = _dbEntities.Releases.Max(m => m.ReleaseID);
                Release release = new Release()
                {
                    ReleaseID = nextReleaseID + 1,
                    SystemGroupCode = softwareReleaseDefinition.ASystemGroupCode,
                    ReleaseCode = softwareReleaseDefinition.SoftwareReleaseCode,
                    ModelYear = softwareReleaseDefinition.ASystemModelYear,
                    VersionNumber = softwareReleaseDefinition.SoftwareVersionNumber,
                    ReleaseTypeID = Convert.ToInt32(softwareReleaseDefinition.SoftwareReleaseTypeName),
                    ConnectCapableIndicator = softwareReleaseDefinition.POCCapable,
                    MinimumConnectClientVersion = softwareReleaseDefinition.MinimumPOCClientNumber,
                    LastModifiedUserName = softwareReleaseDefinition.LastModifiedUserName,
                    CreatedDateTime = softwareReleaseDefinition.CreationDateTime,
                    LastModifiedDateTime = softwareReleaseDefinition.LastModifiedDateTime,
                    ActiveIndicator = softwareReleaseDefinition.IsActive
                };
                _dbEntities.Releases.Add(release);
                _dbEntities.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, release.ReleaseID);
            }
            catch (Exception ex)
            {

                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;

        }
    
        // PUT: Active indicator for a specific SoftwareReleaseID
        [HttpPut, Route(ApiConstants.SOFTWARE_RELEASE_DEFINITIONS)]
        public HttpResponseMessage UpdateSoftwareRelease(SoftwareReleaseDefinition softwareReleaseDefinition)
        {
            HttpResponseMessage response = Request.CreateResponse();

            Release release = _dbEntities.Releases.Where(a => a.ReleaseID == softwareReleaseDefinition.SoftwareReleaseID).FirstOrDefault();
            if(release != null)
            {

                release.ReleaseCode = softwareReleaseDefinition.SoftwareReleaseCode;
                release.ModelYear = softwareReleaseDefinition.ASystemModelYear;
                release.VersionNumber = softwareReleaseDefinition.SoftwareVersionNumber;
                release.ReleaseTypeID = Convert.ToInt32(softwareReleaseDefinition.SoftwareReleaseTypeName);
                release.ConnectCapableIndicator = softwareReleaseDefinition.POCCapable;
                    release.MinimumConnectClientVersion = softwareReleaseDefinition.MinimumPOCClientNumber;
                release.LastModifiedUserName = softwareReleaseDefinition.LastModifiedUserName;
                release.CreatedDateTime = softwareReleaseDefinition.CreationDateTime;
                release.LastModifiedDateTime = softwareReleaseDefinition.LastModifiedDateTime;
                release.ActiveIndicator = softwareReleaseDefinition.IsActive;
                _dbEntities.SaveChanges();
            }
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, release.ReleaseID);
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
        
        // DELETE: SoftwareReleaseDefinition for a specific SoftwareReleaseID
        [HttpDelete, Route(ApiConstants.SOFTWARE_RELEASE_DEFINITIONS + @"/{SoftwareReleaseID}" + @"/{ComponentGroupCode}")]
        public HttpResponseMessage DeleteSoftwareReleaseComponent(int SoftwareReleaseID, string ComponentGroupCode)
        {
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.OK;

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