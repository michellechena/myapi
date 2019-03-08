using SoftwareReleaseMapping.Common;

using SoftwareReleaseMapService.DBModels;
using SoftwareReleaseMapService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftwareReleaseMapService.Controllers
{
 
    public class POCUserController : ApiController
    {
        POCRCEntities1 _dbEntities = new POCRCEntities1();
        public POCUserController()
        {

        }

        // GET: POCUSERRoles
        [HttpGet, Route(ApiConstants.POC_USER_ROLES)]
        public HttpResponseMessage GetPOCUserRoles()
        {
            HttpResponseMessage response = Request.CreateResponse();
            IEnumerable<SoftwarePOCUserRole> pocUserRoles = new List<SoftwarePOCUserRole>();

            try
            {
                pocUserRoles = (from pcu in _dbEntities.POCUserRoles
                                select new SoftwarePOCUserRole {
                                    RoleId = pcu.RoleId,
                                    Permission =pcu.Permission,
                                    RoleName = pcu.RoleName
                                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, pocUserRoles);
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        // GET: POCUSERPERMISSIONS
        [HttpGet, Route(ApiConstants.POC_USER_PERMISSIONS)]
        public HttpResponseMessage GetPOCUserPermissions()
        {
            HttpResponseMessage response = Request.CreateResponse();
            IEnumerable<POCUser> pocUsers = new List<POCUser>();

            try
            {
                pocUsers = (from pr in _dbEntities.POCUsers
                            join pu in _dbEntities.POCUserRoles on pr.RoleId equals pu.RoleId
                            
                            select new
                            {
                                Id = pr.Id,
                                Permission = pu.Permission,
                                UserName = pr.UserName,
                                RoleId = pu.RoleId,
                                RoleName = pu.RoleName,
                                CreatedDateTime = pr.CreatedDateTime,
                                LastModifiedDateTime = pr.LastModifiedDateTime
                            }).AsEnumerable().Select(s => new POCUser()
                            {
                                Id = s.Id,
                                Permission = s.Permission,
                                UserName = s.UserName,
                                RoleId = s.RoleId,
                                RoleName = s.RoleName,
                                CreatedDateTime = s.CreatedDateTime,
                                LastModifiedDateTime = s.LastModifiedDateTime
                            }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, pocUsers);
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }
        // GET: POCUserPermission for a specific UserId
        [HttpGet, Route(ApiConstants.POC_USER_PERMISSIONS + @"/{UserId}")]
        public HttpResponseMessage GetPOCUserPermissionByUserId(int UserId)
        {
            HttpResponseMessage response = Request.CreateResponse();
            POCUser pocUser = new POCUser();
            try
            {
                pocUser =   (from u in _dbEntities.POCUsers where u.Id == UserId select u).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, pocUser);
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }
        // POST: Add new POCUser Permission
        [HttpPost, Route(ApiConstants.POC_USER_PERMISSIONS)]
        public HttpResponseMessage AddPOCUser(POCUser pocUser)
        {
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                 
                _dbEntities.POCUsers.Add(pocUser);
                _dbEntities.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, pocUser.Id);
            }
            catch (Exception ex)
            {

                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;

        }
        // PUT: Update POCUser Permission 
        [HttpPut, Route(ApiConstants.POC_USER_PERMISSIONS)]
        public HttpResponseMessage UpdatePOCUser(POCUser pocUser)
        {
            HttpResponseMessage response = Request.CreateResponse();
            POCUser pocUserTemp = _dbEntities.POCUsers.Where(a => a.Id == pocUser.Id).FirstOrDefault();
            try
            {
                if (pocUserTemp != null)
                {
                    pocUserTemp.UserName = pocUser.UserName;
                    pocUserTemp.RoleId = pocUser.RoleId;
                    pocUserTemp.LastModifiedDateTime = pocUser.LastModifiedDateTime;
                    _dbEntities.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, pocUser.Id);
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
        // DELETE: POCUser for a specific UserId
        [HttpDelete, Route(ApiConstants.POC_USER_PERMISSIONS + @"/{UserId}")]
        public HttpResponseMessage DeletePOCUser(int UserId)
        {
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                POCUser pocUser = _dbEntities.POCUsers.Where(a => a.Id == UserId).FirstOrDefault();
                if(pocUser != null)
                {
                    _dbEntities.POCUsers.Remove(pocUser);
                    _dbEntities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, false);

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
