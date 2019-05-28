using Autofac;
using Equipment.Rental.Models;
using Equipment.Rental.Models.Models;
using Equipment.Rental.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Equipment.Rental.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class OrderController : ApiController
    {
        protected static readonly ILogger Logger = LogManager.GetLogger("OrderController");
        private readonly ICartService _cartService;
        public OrderController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// Adding to cart
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addToCart")]
        public async Task<bool> AddToCart([FromBody] CartRequest data)
        {
            try
            {
                if (data == null)
                    throw new ArgumentNullException("There is no cart !");

                var result = await _cartService.AddEquipmentsToCartAsync(data.Id, data.RentDays, data.MachineHashId);
                return result;
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
           
        }

        /// <summary>
        /// Cart list
        /// </summary>
        /// <param name="machineHashId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("cartList")]
        public List<RentEquipment> CartList([FromUri]string machineHashId)
        {
            try
            {
                if (string.IsNullOrEmpty(machineHashId))
                    throw new ArgumentNullException("There is no machine hash id !");

                var result = _cartService.GetCartList(machineHashId);
                return result;
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
