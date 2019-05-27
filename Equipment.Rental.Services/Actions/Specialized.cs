using Equipment.Rental.Common;
using Equipment.Rental.Models;
using System.Collections.Generic;

namespace Equipment.Rental.Services.Actions
{
    public class Specialized : IActionCalculator<Order>
    {
        public Order Calculate(RentEquipment rentEquipment, Dictionary<FeeTypes, decimal> fees)
        {
            if (rentEquipment.Type != EquipmentType.Specialized
                 || fees.Count == 0) return null;

            var price = rentEquipment.RentDays <= 3 ? rentEquipment.RentDays * fees[FeeTypes.PremiumDaily]
                     : 3 * fees[FeeTypes.PremiumDaily] + (rentEquipment.RentDays - 3) * fees[FeeTypes.RegularDaily];

            return new Order
            {
                Amount = price,
                Id = rentEquipment.Id,
                Name = rentEquipment.Name,
                RentDays = rentEquipment.RentDays,
                Type = EquipmentType.Specialized
            };
        }
    }
}
