using Equipment.Rental.Models;
using Equipment.Rental.Models.Models;
using System.Collections.Generic;

namespace Equipment.Rental.Services.Calculations
{
    public interface IInvoiceCalculator
    {
        Invoice Prepare(List<Order> orders);
    }
}
