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
    public class OrderCalculator : IOrderCalculator
    {
        public List<Order> _invoices { get; set; }
        private IList<IActionCalculator> _actions;
        private readonly IInventoryRepository _inventoryRepository;
        public OrderCalculator(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            _actions = new List<IActionCalculator>();
            Initialize();
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

        private void Initialize()
        {
            _actions.Add(new Heavy());
            _actions.Add(new Regular());
            _actions.Add(new Specialized());
        }
    }
}
