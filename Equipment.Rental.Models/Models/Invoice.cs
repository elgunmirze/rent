using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Models.Models
{
    public class Invoice
    {
        public IEnumerable<Order> Orders { get; set; }
        public decimal TotalAmount { get; set; }
        public int Points { get; set; }
    }
}
