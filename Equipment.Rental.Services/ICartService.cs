using Equipment.Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services
{
    public interface ICartService
    {
        Task<bool> AddEquipmentsToCartAsync(int id, int rentDays, string machineHashId);
        List<RentEquipment> GetCartList(string machineHashId);
    }
}
