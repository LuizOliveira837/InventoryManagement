using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    [Table("[Supplier]")]
    public class Supplier
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string CEP { get; set; }
        public string DDD { get; set; }
        public string Cel { get; set; }

        [Write(false)]
        public IList<Product> Products { get; set;}


        public Supplier()
        {
            this.Products = new List<Product>();
        }
    }
}
