using AutoFixture;
using Equipment.Rental.Common;
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
        public void Given_RentEquipments_When_CalculatingPrices_Then_CreateCalculatedInvioces_1()
        {
            //arrange
            var fixture = new Fixture();
            var fees = fixture.Create<Dictionary<FeeTypes, decimal>>();
            _inventoryRepository.GetEquipmentFees().Returns(fees);

            var rentEquipments = fixture.Create<List<RentEquipment>>();
            var orderCalculator = new OrderCalculator(_inventoryRepository);

            //act
            orderCalculator.Calculate(rentEquipments);

            //assert
            Assert.NotNull(orderCalculator._invoices);
            Assert.True(orderCalculator._invoices.Count > 0);
        }


        [Fact]
        public void Given_RentEquipments_When_CalculatingPrices_Then_CreateCalculatedInvoice_ForHeavy_Rule()
        {
            //arrange
            var fees = GetFees();

            _inventoryRepository.GetEquipmentFees().Returns(fees);

            var rentEquipments = new List<RentEquipment>
            {
                new RentEquipment
                {
                    Id = 1,
                    Name = "test",
                    RentDays = 5,
                    Type = EquipmentType.Heavy
                }
            };
            var orderCalculator = new OrderCalculator(_inventoryRepository);

            //act
            orderCalculator.Calculate(rentEquipments);

            //assert
            Assert.NotNull(orderCalculator._invoices);
            Assert.Equal(EquipmentType.Heavy, orderCalculator._invoices.Select(i => i.Type).FirstOrDefault());
            Assert.Equal(11, orderCalculator._invoices.Select(i=>i.Amount).FirstOrDefault());
        }

        [Fact]
        public void Given_RentEquipments_When_CalculatingPrices_Then_CreateCalculatedInvoiceRegular_For_Rule()
        {
            //arrange
            var fees = GetFees();

            _inventoryRepository.GetEquipmentFees().Returns(fees);

            var rentEquipments = new List<RentEquipment>
            {
                new RentEquipment
                {
                    Id = 1,
                    Name = "test",
                    RentDays = 17,
                    Type = EquipmentType.Regular
                }
            };
            var orderCalculator = new OrderCalculator(_inventoryRepository);

            //act
            orderCalculator.Calculate(rentEquipments);

            //assert
            Assert.NotNull(orderCalculator._invoices);
            Assert.Equal(EquipmentType.Regular, orderCalculator._invoices.Select(i => i.Type).FirstOrDefault());
            Assert.Equal(49, orderCalculator._invoices.Select(i => i.Amount).FirstOrDefault());
        }

        [Fact]
        public void Given_RentEquipments_When_CalculatingPrices_Then_CreateCalculatedInvoiceSpecialized_For_Rule()
        {
            //arrange
            var fees = GetFees();
            _inventoryRepository.GetEquipmentFees().Returns(fees);
            var rentEquipments = new List<RentEquipment>
            {
                new RentEquipment
                {
                    Id = 1,
                    Name = "test",
                    RentDays = 33,
                    Type = EquipmentType.Specialized
                }
            };
            var orderCalculator = new OrderCalculator(_inventoryRepository);

            //act
            orderCalculator.Calculate(rentEquipments);

            //assert
            Assert.NotNull(orderCalculator._invoices);
            Assert.Equal(EquipmentType.Specialized ,orderCalculator._invoices.Select(i => i.Type).FirstOrDefault());
            Assert.Equal(96, orderCalculator._invoices.Select(i => i.Amount).FirstOrDefault());
        }

        [Fact]
        public void Given_NullRentEquipments_When_CalculatingPrices_Then_NullArgumentExeption()
        {
            //arrange
            var fees = GetFees();
            _inventoryRepository.GetEquipmentFees().Returns(fees);
         
            var orderCalculator = new OrderCalculator(_inventoryRepository);

            //assert
            Assert.Throws<ArgumentNullException>(() => orderCalculator.Calculate(null));
        }


        private static Dictionary<FeeTypes, decimal> GetFees()
        {
            var fixture = new Fixture();
            var fees = fixture.Create<Dictionary<FeeTypes, decimal>>();
            fees[FeeTypes.OnTimeRental] = 1;
            fees[FeeTypes.PremiumDaily] = 2;
            fees[FeeTypes.RegularDaily] = 3;

            return fees;
        }
    }
}
