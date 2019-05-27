using Equipment.Rental.Common;
using Equipment.Rental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Infrastructure.Repository
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<EquipmentDto>> GetAllEquipmentsAsync();
        Dictionary<FeeTypes, decimal> GetEquipmentFees();
    }
}
