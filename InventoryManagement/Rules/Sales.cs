using InventoryManagement.Models;
using InventoryManagement.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Rules
{
    public static class Sales
    {
        public static SupplierRepository supplierRepository;

        public static bool SupplierHasProduct(SqlConnection connection, Supplier supplier, Product product)
        {
            supplierRepository = new SupplierRepository(connection);

            var suppliers = supplierRepository.GetSupplierProducts(supplier.Id);

            var productAux = suppliers.Products.FirstOrDefault<Product>(prd => prd.Id == product.Id);

            if (productAux == null) return false;

            return true;
        }




    }
}
