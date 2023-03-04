using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    [Table("[Pharmacy]")]
    public class Pharmacy
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Cnpj { get; set; }
        public String CEP { get; set; }
        public String DDD { get; set; }
        public String Cel { get; set; }

    
    }
}
