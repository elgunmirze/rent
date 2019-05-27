using Equipment.Rental.Common;
using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services.Actions
{
    public class Regular : IActionCalculator<Order>
    {
        public Order Calculate(RentEquipment rentEquipment, Dictionary<FeeTypes, decimal> fees)
        {
            if (rentEquipment.Type != EquipmentType.Regular) return null;
            
            var price = fees[FeeTypes.OnTimeRental] +
                 rentEquipment.RentDays <= 2 ? rentEquipment.RentDays * fees[FeeTypes.PremiumDaily]
                     : 2 * fees[FeeTypes.PremiumDaily] + (rentEquipment.RentDays - 2) * fees[FeeTypes.RegularDaily];

            return new Order
            {
                Amount = price,
                Id = rentEquipment.Id,
                Name = rentEquipment.Name,
                RentDays = rentEquipment.RentDays,
                Type = EquipmentType.Regular
            };
        }
    }
}