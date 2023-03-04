using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    [Table("[Order]")]
    public class Order
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float UnitaryValue { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
