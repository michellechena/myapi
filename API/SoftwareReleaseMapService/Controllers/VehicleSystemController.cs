//using SoftwareReleaseMapping.Common.Models;
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

namespace SoftwareReleaseMapService.Controllers
{
    public class ASystemController : ApiController
    {
        public ASystemController()
        {

        }

        [HttpGet, Route(ApiConstants.A_SYSTEMS)]
        public HttpResponseMessage GetASystemsGroups()
        {
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                var output = "[{\"VinLastEight\":null,\"ASystemGroupCode\":\"EMS\",\"ASystemGroupName\":\"Engine Management System\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"PCC\",\"VehicleSystemGroupName\":\"Predictive Cruise Control\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"VCS\",\"VehicleSystemGroupName\":\"Vehicle Control System\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"CMP\",\"VehicleSystemGroupName\":\"Chassis Module - Primary\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"CMS\",\"VehicleSystemGroupName\":\"Chassis Module - Secondary\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"MSM\",\"VehicleSystemGroupName\":\"Master Switch Module\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"RHS\",\"VehicleSystemGroupName\":\"Right Hand Stalk\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"TCM\",\"VehicleSystemGroupName\":\"Transmission Control Module\"},{\"VinLastEight\":null,\"VehicleSystemGroupCode\":\"BBM\",\"VehicleSystemGroupName\":\"Body Builder Module\"}]";

                response.Content = new StringContent(output, Encoding.UTF8, "application/json");
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("[]");
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

		[HttpGet, Route(ApiConstants.A_SYSTEM_COMPONENT_GROUPS + @"/{ASystemGroupCode}")]
        public HttpResponseMessage GetASystemComponentGroup(string aSystemGroupCode)
        {
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                var output = "[{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1020\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1021\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1022\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1030\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1031\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1032\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1033\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1065\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1073\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1080\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1083\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1084\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1087\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1088\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1097\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1118\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1267\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1268\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1269\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1274\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1281\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1283\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1294\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1297\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1298\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"},{\"SoftwareReleaseID\":0,\"ComponentGroupCode\":\"1299\",\"ComponentNumber\":null,\"SoftwareReleaseDerivationIndicator\":false,\"ComponentNumberSpecWeek\":null,\"LastModifiedUserName\":null,\"CreatedDateTime\":\"0001-01-01T00:00:00\",\"LastModifiedDateTime\":\"0001-01-01T00:00:00\"}]";

                response.Content = new StringContent(output, Encoding.UTF8, "application/json");
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