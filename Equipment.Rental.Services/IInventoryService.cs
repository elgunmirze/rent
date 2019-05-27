using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services
{
    public interface IInventoryService
    {
        Task<List<Models.Equipment>> GetEquipmentsAsync();
    }
}
