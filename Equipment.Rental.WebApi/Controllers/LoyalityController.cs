using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Equipment.Rental.WebApi.Controllers
{
    [RoutePrefix("Loyality")]
    public class LoyalityController : ApiController
    {
        [HttpPost]
        [Route("Calculate")]
        public int CalculateLoyalityPoints(int customerId)
        {
            return 0;
        }
    }
}
