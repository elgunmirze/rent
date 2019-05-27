using Equipment.Rental.Common;
using Equipment.Rental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Infrastructure.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        public async Task<IEnumerable<EquipmentDto>> GetAllEquipmentsAsync()
        {
            var equipments = await Task.FromResult(new List<EquipmentDto>
            {
                new EquipmentDto
                {
                    Id = 1,
                    Name = "Caterpillar bulldozer",
                    Type = Common.EquipmentType.Heavy
                },
                new EquipmentDto
                {
                    Id = 2,
                    Name = "KamAZ truck",
                    Type = Common.EquipmentType.Regular
                },
                new EquipmentDto
                {
                    Id = 3,
                    Name = "Komatsu crane",
                    Type = Common.EquipmentType.Heavy
                },
                new EquipmentDto
                {
                    Id = 4,
                    Name = "Volvo steamroller",
                    Type = Common.EquipmentType.Regular
                },
                new EquipmentDto
                {
                    Id = 5,
                    Name = "Bosch jackhammer",
                    Type = Common.EquipmentType.Specialized
                }
            });

            return equipments;
        }

        public Dictionary<FeeTypes,decimal> GetEquipmentFees()
        {
            var fees = new Dictionary<FeeTypes, decimal>
            {
                { FeeTypes.OnTimeRental, 100 },
                { FeeTypes.PremiumDaily, 60 },
                { FeeTypes.RegularDaily, 40 },
            };
            return fees;
        }
    }
}
