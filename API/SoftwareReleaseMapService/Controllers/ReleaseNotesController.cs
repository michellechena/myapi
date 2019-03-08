
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
using SoftwareReleaseMapping.Common.Models;
using SoftwareReleaseMapping.Common;
using System.Data.Entity;
using SoftwareReleaseMapService.DBModels;

namespace SoftwareReleaseMapService.Controllers
{
    public class ReleaseNotesController : ApiController
    {
        POCRCEntities1 _dbEntities = new POCRCEntities1();
        [HttpGet, Route(ApiConstants.RELEASE_NOTES + @"/{SoftwareReleaseID}" + @"/{Language}" + @"/{SoftwareReleaseNoteTypeCode}")]
        public HttpResponseMessage GetReleaseNotes(string SoftwareReleaseID , string language,string SoftwareReleaseNoteTypeCode)
        {
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                int softwareReleaseId = 0;
                if (!string.IsNullOrEmpty(SoftwareReleaseID))
                    softwareReleaseId = Convert.ToInt32(SoftwareReleaseID);
                int MicrosoftLocaleID = Convert.ToInt32(language);
                List<SoftwareReleaseNote> softwareReleaseNoteList = (from dt in _dbEntities.DialectTexts
                                                                       join rn in _dbEntities.ReleaseNotes on dt.TextID equals rn.ReleaseNoteTextID
                                                                       where rn.ReleaseID == softwareReleaseId && rn.ReleaseNoteTypeCode == SoftwareReleaseNoteTypeCode 
                                                                       && dt.MicrosoftLocaleID == MicrosoftLocaleID select new SoftwareReleaseNote {
                                                                           SoftwareReleaseId = rn.ReleaseID,
                                                                           ReleaseNote = dt.LanguageText,
                                                                           SoftwareReleaseNoteTypeCode = rn.ReleaseNoteTypeCode,
                                                                           ReleaseNoteTextId = rn.ReleaseNoteTextID
                                                                       }).OrderByDescending(o=>o.ReleaseNoteTextId).ToList();
                

                if(softwareReleaseNoteList.Count > 0)
                {
                    SoftwareReleaseNote softwareReleaseNote = new SoftwareReleaseNote();
                    softwareReleaseNote = softwareReleaseNoteList.FirstOrDefault();
                    return Request.CreateResponse(HttpStatusCode.OK, softwareReleaseNote);
                }
                
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }
        
        [HttpPost, Route(ApiConstants.RELEASE_NOTES)]
        public HttpResponseMessage AddSoftwareReleaseNotes(SoftwareReleaseNote softwareReleaseNotes)
        {
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                TextReference textReference = new TextReference();
                textReference.TextID = _dbEntities.TextReferences.Max(m => m.TextID) + 1;
                _dbEntities.TextReferences.Add(textReference);
                _dbEntities.SaveChanges();
                ReleaseNote releaseNoteTemp = _dbEntities.ReleaseNotes.Where(a => a.ReleaseID == softwareReleaseNotes.SoftwareReleaseId
                                                                            && a.ReleaseNoteTypeCode == softwareReleaseNotes.SoftwareReleaseNoteTypeCode 
                                                                            && a.ReleaseNoteTextID == textReference.TextID
                                                                            ).FirstOrDefault();
                if (releaseNoteTemp == null) {
                    
                    ReleaseNote releaseNote = new ReleaseNote()
                    {
                        ReleaseID = softwareReleaseNotes.SoftwareReleaseId,
                        ReleaseNoteTypeCode = softwareReleaseNotes.SoftwareReleaseNoteTypeCode,
                        ReleaseNoteTextID = textReference.TextID,
                        LastModifiedUserName = softwareReleaseNotes.LastModifiedUserName,
                        CreatedDateTime = softwareReleaseNotes.CreatedDateTime,
                        LastModifiedDateTime = softwareReleaseNotes.LastModifiedDateTime
                    };
                    _dbEntities.ReleaseNotes.Add(releaseNote);
                    _dbEntities.SaveChanges();
                    DialectText dialectText = new DialectText()
                    {
                        MicrosoftLocaleID = Convert.ToInt32(softwareReleaseNotes.Language),
                        TextID = textReference.TextID,
                        LanguageText = softwareReleaseNotes.ReleaseNote,
                        ModifiedbyDatabaseLoginName = softwareReleaseNotes.LastModifiedUserName,
                        ModificationDateTime = softwareReleaseNotes.LastModifiedDateTime
                    };
                    _dbEntities.DialectTexts.Add(dialectText);
                    _dbEntities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, softwareReleaseNotes.SoftwareReleaseId);
                }
                return Request.CreateResponse(HttpStatusCode.Ambiguous, softwareReleaseNotes.SoftwareReleaseId);

            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;

        }

       [HttpPut, Route(ApiConstants.RELEASE_NOTES)]      
        public HttpResponseMessage EditSoftwareReleaseNotes(SoftwareReleaseNote softwareReleaseNotes)
        {
            HttpResponseMessage response = Request.CreateResponse();
             
            try
            {
                ReleaseNote releaseNote = _dbEntities.ReleaseNotes.Where(a => a.ReleaseID == softwareReleaseNotes.SoftwareReleaseId 
                                                                        && a.ReleaseNoteTypeCode ==softwareReleaseNotes.SoftwareReleaseNoteTypeCode
                                                                        ).FirstOrDefault();
                if (releaseNote != null)
                {
                    releaseNote.ReleaseNoteTypeCode = softwareReleaseNotes.SoftwareReleaseNoteTypeCode;
                    releaseNote.LastModifiedDateTime = softwareReleaseNotes.LastModifiedDateTime;
                    releaseNote.LastModifiedUserName = softwareReleaseNotes.LastModifiedUserName;
                    releaseNote.CreatedDateTime = softwareReleaseNotes.CreatedDateTime;
                    _dbEntities.SaveChanges();
                }
                int LocaleID = Convert.ToInt32(softwareReleaseNotes.Language);
                DialectText dialectText = _dbEntities.DialectTexts.Where(a => a.MicrosoftLocaleID == LocaleID&& a.TextID== releaseNote.ReleaseNoteTextID).FirstOrDefault();
                if(dialectText !=null)
                {
                    dialectText.LanguageText = softwareReleaseNotes.ReleaseNote;
                    _dbEntities.SaveChanges();
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, releaseNote.ReleaseID);

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