using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Rental.Services
{
    public interface IInventoryService
    {
        Task<List<Models.Equipment>> GetEquipmentsAsync();
    }
}
