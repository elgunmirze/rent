using Equipment.Rental.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Rental.Services
{
    public interface ICartService
    {
        Task<bool> AddEquipmentsToCartAsync(int id, int rentDays, string machineHashId);
        List<RentEquipment> GetCartList(string machineHashId);
        bool ClearCartList(string machineHashId);
    }
}