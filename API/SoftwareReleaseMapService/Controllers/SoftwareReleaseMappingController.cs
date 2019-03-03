using SoftwareReleaseMapping.Common;
using SoftwareReleaseMapping.Common.Models;
//using SoftwareReleaseMapping.Data;
//using SoftwareReleaseMapping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SoftwareReleaseMapService.Controllers
{
    public class SoftwareReleaseMappingController : ApiController
    {
        public SoftwareReleaseMappingController()
        {
        }

        // GET api/<controller>
        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_MAPS)]
        public List<SoftwareReleaseMap> GetAllChassisSoftwareReleaseMaps()
        {
            var queryStringValue = HttpContext.Current.Request.QueryString["ASystemGroupCode"];

            if (queryStringValue != null)
            {
            }
            else
            {
            }
			return null;
        }
        // GET api/<controller>
        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_MAPS + @"/{VinLastEight}")]
        public List<SoftwareReleaseMap> GetSoftwareReleaseMapByVinLastEight(string VinLastEight)
        {
			return null;
        }


        // GET api/<controller>
        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_MAPS + @"/{VinLastEight}/" + ApiConstants.SOFTWARE_RELEASE_CODES)]
        public List<string> GetSoftwareReleasCodesbyVin(string VinLastEight)
        {
			return null;
        }


        // GET api/<controller>
        [HttpGet, Route(ApiConstants.SOFTWARE_RELEASE_CODES)]
        public List<string> GetSoftwareReleasCodes()
        {
			return null;
        }

        // POST api/<controller>
        [HttpPost, Route(ApiConstants.SOFTWARE_RELEASE_MAPS)]
        public List<SoftwareReleaseMap> SoftwareReleaseMapByVins(List<ChassisAndASystemCode> ChassisAndASystemCode)
        {
			return null;
        }

       
    }
}