using Autofac;
using AutoMapper;
using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Models;
using Equipment.Rental.Models.Models;
using Equipment.Rental.Services.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Equipment.Rental.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class PriceController : ApiController
    {
        private readonly IOrderCalculator _orderCalculator;
        private readonly IInvoiceCalculator _invoiceCalculator;
        public PriceController(IInvoiceCalculator invoiceCalculator, IOrderCalculator orderCalculator)
        {
            _invoiceCalculator = invoiceCalculator;
            _orderCalculator = orderCalculator;
        }


        [HttpPost]
        [Route("invoice")]
        public Invoice Calculate([FromBody] List<RentEquipmentRequest> data)
        {
            var request = Mapper.Map<List<RentEquipment>>(data);

            _orderCalculator.Calculate(request);

            var result = _invoiceCalculator.Prepare(_orderCalculator._invoices);

            return result;
        }
    }
}
