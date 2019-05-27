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
    public class InventoryController : ApiController
    {
        protected ILifetimeScope Scope { get; }
        public InventoryController(ILifetimeScope scope)
        {
            Scope = scope;
        }

        /// <summary>
        /// Get all equipments from inventory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Models.Equipment>> GetEquipments()
        {
            var inventoryService = Scope.Resolve<IInventoryService>();
            var result = await inventoryService.GetEquipmentsAsync();
            return result;
        }
    }
}
