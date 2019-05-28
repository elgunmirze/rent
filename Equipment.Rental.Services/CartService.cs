using Equipment.Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services
{
    public class CartService : ICartService
    {
        private const int CACHE_TIME_IN_MINUTES = 5;

        public readonly IInventoryService _inventoryService;
        public CartService(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<bool> AddEquipmentsToCartAsync(int id, int rentDays, string machineHashId)
        {
            var equipments = await _inventoryService.GetEquipmentsAsync();
            var equipment = equipments.Where(e => e.Id == id).FirstOrDefault();

            var cache = MemoryCache.Default;
            var cartList = (List<RentEquipment>)cache[machineHashId];

            if (cartList == null)
            {
                cartList = new List<RentEquipment>();
            }

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(CACHE_TIME_IN_MINUTES)
            };

            if(cartList.Any(c=>c.Id == id))
            {
               cartList.Where(c => c.Id == id).Select(c => { c.RentDays += rentDays; return c; }).ToList();
            }
            else
            {
                cartList.Add(new RentEquipment
                {
                    Id = equipment.Id,
                    Name = equipment.Name,
                    RentDays = rentDays,
                    Type = equipment.Type
                });
            }

            cache.Set(machineHashId, cartList, policy);

            return true;
        }

        public List<RentEquipment> GetCartList(string machineHashId)
        {
            var cache = MemoryCache.Default;
            var cartList = (List<RentEquipment>)cache[machineHashId];

            if (cartList == null)
            {
                cartList = new List<RentEquipment>();
            }

            return cartList;
        }

        public bool ClearCartList(string machineHashId)
        {
            var cache = MemoryCache.Default;
            cache.Remove(machineHashId);
            return true;
        }
    }
}
