using Equipment.Rental.Models;
using Equipment.Rental.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services.Calculations
{
    public class InvoiceCalculator : IInvoiceCalculator<Invoice>
    {
        public Invoice PrepareInvoice(List<Order> orders)
        {
            if (!orders.Any()) return new Invoice();

            var invoice = new Invoice
            {
                Order = orders,
                Points = PointsCalculator(orders),
                TotalAmount = orders.Sum(o => o.Amount)
            };

            return invoice;
        }

        private static int PointsCalculator(List<Order> orders)
        {
            if (!orders.Any()) return 0;

            var points = 0;
            orders.ForEach(o =>
            {
                if (o.Type == Common.EquipmentType.Heavy)
                {
                    points += 2;
                }
                else
                {
                    points += 1;
                }
            });

            return points;
        }
    }
}
