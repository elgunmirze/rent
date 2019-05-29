using Autofac;
using AutoMapper;
using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Models;
using Equipment.Rental.Models.Models;
using Equipment.Rental.Services;
using Equipment.Rental.Services.Calculations;
using NLog;
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
        private readonly ICartService  _cartService;
        protected static readonly ILogger Logger = LogManager.GetLogger("PriceController");

        public PriceController(IInvoiceCalculator invoiceCalculator, 
            IOrderCalculator orderCalculator,
            ICartService cartService)
        {
            _invoiceCalculator = invoiceCalculator;
            _orderCalculator = orderCalculator;
            _cartService = cartService;
        }


        /// <summary>
        /// Calculating Invoices
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("invoice")]
        public Invoice Calculate([FromBody] List<RentEquipmentRequest> data)
        {
            try
            {
                if (data == null)
                    throw new ArgumentNullException("There is no rent equipments 1");

                Logger.Info("Invoice calulation");

                var request = Mapper.Map<List<RentEquipment>>(data);

                _orderCalculator.Calculate(request);

                var result = _invoiceCalculator.Prepare(_orderCalculator._invoices);

                return result;
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Clearing the cart list
        /// </summary>
        /// <param name="machineHashId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("emptycartlist")]
        public bool ClearCache([FromBody]string machineHashId)
        {
            try
            {
                if (string.IsNullOrEmpty(machineHashId))
                    throw new ArgumentNullException("There is no machine hash id !");

                return _cartService.ClearCartList(machineHashId);
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
