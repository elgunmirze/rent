using Equipment.Rental.Common;
using Equipment.Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services
{
    public interface IActionCalculator<T>
    {
        T Calculate(RentEquipment rentEquipment, Dictionary<FeeTypes, decimal> fees);
    }
}
