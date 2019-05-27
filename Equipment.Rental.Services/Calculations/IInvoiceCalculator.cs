using Equipment.Rental.Models;
using Equipment.Rental.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services.Calculations
{
    public interface IInvoiceCalculator
    {
        Invoice Prepare(List<Order> orders);
    }
}
