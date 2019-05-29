using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using AutoFixture;
using Equipment.Rental.Services;
using Xunit;

namespace Equipment.Rental.Tests
{
    public class CartServiceTests
    {
        public readonly IInventoryService _inventoryService;
        public CartServiceTests()
        {
            _inventoryService = Substitute.For<IInventoryService>();
        }

        //[Fact]
        //public Task Given_IdAndRentDaysAndMachineIDForCache_Then_Add_ToCartList()
        //{

        //}
    }
}
