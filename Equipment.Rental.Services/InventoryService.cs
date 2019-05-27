using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading.Tasks;
using AutoMapper;

namespace Equipment.Rental.Services
{
    public class InventoryService
    {
        private const int CACHE_TIME_IN_MINUTES = 60;
        private const string ALL_EQUIPMENTS_CACHE = "11717d90-6uuf-4d5d-bc95-b010fe13c9c0";

        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Models.Equipment>> GetEquipmentsAsync()
        {
            ObjectCache cache = MemoryCache.Default;
            var inventories = (IEnumerable<EquipmentDto>)cache[ALL_EQUIPMENTS_CACHE];

            if (inventories == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(CACHE_TIME_IN_MINUTES)
                };
                inventories = await _inventoryRepository.GetAllEquipmentsAsync();
                cache.Set(ALL_EQUIPMENTS_CACHE, inventories, policy);
            }

            var mappedInventories = Mapper.Map<IEnumerable<EquipmentDto>, IEnumerable<Models.Equipment>>(inventories);
            return mappedInventories;
        }
    }
}
