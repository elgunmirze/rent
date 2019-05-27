using Equipment.Rental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public int RentDays { get; set; }
        public decimal Amount { get; set; }
    }
}
