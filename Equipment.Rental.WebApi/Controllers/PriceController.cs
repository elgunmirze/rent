using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Models;
using Equipment.Rental.Services.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Equipment.Rental.WebApi.Controllers
{
    public class PriceController : ApiController
    {
        [HttpPost]
        public void Calculate([FromBody] List<RentEquipment> rentEquipments)
        {
            var ca = new OrderCalculator(new InventoryRepository());
            ca.Calculate(rentEquipments);
        }
    }
}
