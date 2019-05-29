using AutoFixture;
using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Models;
using Equipment.Rental.Services.Calculations;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Equipment.Rental.Tests
{
    public class OrderCalculatorTests
    {
        public readonly IInventoryRepository _inventoryRepository;
        public OrderCalculatorTests()
        {
            _inventoryRepository = Substitute.For<IInventoryRepository>();
        }

        [Fact]
        public void Given_RentEquipments_When_CalculatingPrices_Then_CreateCalculatedInvioces()
        {
            //arrange
            var fixture = new Fixture();
            var rentEquipments = fixture.Create<IEnumerable<RentEquipment>>();
            var orderCalculator = new OrderCalculator(_inventoryRepository);
            orderCalculator.Calculate(rentEquipments);

            //assert
            Assert.True(orderCalculator._invoices.Count > 0);

        }
    }
}
