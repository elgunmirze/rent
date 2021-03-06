﻿using Equipment.Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Rental.Services.Calculations
{
    public interface IOrderCalculator
    {
        void Calculate(IEnumerable<RentEquipment> rentEquipments);
        List<Order> _invoices { get; set; }
    }
}
