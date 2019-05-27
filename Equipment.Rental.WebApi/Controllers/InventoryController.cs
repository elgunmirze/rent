using Autofac;
using Equipment.Rental.Models.Entities;
using Equipment.Rental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Equipment.Rental.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class InventoryController : ApiController
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Get all equipments from inventory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("equipments")]
        public async Task<List<Models.Equipment>> GetEquipments()
        {
            var result = await _inventoryService.GetEquipmentsAsync();
            return result;
        }
    }
}
