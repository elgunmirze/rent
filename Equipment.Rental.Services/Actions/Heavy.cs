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
    public class Heavy : IActionCalculator<Order>
    {
        public Order Calculate(RentEquipment rentEquipment, Dictionary<FeeTypes, decimal> fees)
        {
            if (rentEquipment.Type != EquipmentType.Heavy) return null;

            var price = fees[FeeTypes.OnTimeRental] +
                rentEquipment.RentDays * fees[FeeTypes.PremiumDaily];
            

            return new Order
            {
                Amount = price,
                Id = rentEquipment.Id,
                Name = rentEquipment.Name,
                RentDays = rentEquipment.RentDays,
                Type = EquipmentType.Heavy
            };
        }
    }
}
