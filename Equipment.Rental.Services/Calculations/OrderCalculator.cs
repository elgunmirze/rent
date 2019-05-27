using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Models;
using Equipment.Rental.Services.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services.Calculations
{
    public class OrderCalculator
    {
        public List<Order> _invoices { get; set; }
        private IList<IActionCalculator<Order>> _actions = new List<IActionCalculator<Order>>();
        private readonly IInventoryRepository _inventoryRepository;
        public OrderCalculator(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            InitActions();
        }

        private void InitActions()
        {
            _actions.Add(new Heavy());
            _actions.Add(new Regular());
            _actions.Add(new Specialized());
        }
        public void Calculate(IEnumerable<RentEquipment> rentEquipments)
        {
            var fees = _inventoryRepository.GetEquipmentFees();

            _invoices = new List<Order>();

            foreach (var action in _actions)
            {
                foreach (var rentEquipment in rentEquipments)
                {
                    var invoice = action.Calculate(rentEquipment, fees);

                    if(invoice != null)
                    {
                        _invoices.Add(invoice);
                    }
                }
            }
        }
    }
}
