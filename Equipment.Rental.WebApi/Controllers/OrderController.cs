using Autofac;
using Equipment.Rental.Models;
using Equipment.Rental.Models.Models;
using Equipment.Rental.Services;
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
        private readonly ICartService _cartService;
        public OrderController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [Route("addToCart")]
        public async Task<bool> AddToCart([FromBody] CartRequest data)
        {
            var result = await _cartService.AddEquipmentsToCartAsync(data.id, data.rentDays, data.machineHashId);
            return result;
        }

        [HttpGet]
        [Route("cartList")]
        public List<RentEquipment> CartList([FromUri]string machineHashId)
        {
            var result = _cartService.GetCartList(machineHashId);
            return result;
        }
    }
}
