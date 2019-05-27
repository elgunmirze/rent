using Equipment.Rental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace Equipment.Rental.WebApi.Controllers
{
    public class InventoryController : ApiController
    {
        [HttpGet]
        public IEnumerable<EquipmentDto> GetEquipments()
        {
            return null;
        }
    }
}
