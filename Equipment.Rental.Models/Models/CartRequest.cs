using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Equipment.Rental.Models.Models
{
    public class CartRequest
    {
        public int id { get; set; }
        public int rentDays { get; set; }
        public string machineHashId { get; set; }
    }
}
