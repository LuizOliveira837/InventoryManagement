using Dapper.Contrib.Extensions;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using InventoryManagement.Rules;
using Microsoft.Data.SqlClient;
using System;

namespace InventoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            String CONNECTION_STRING = "Server=GIP-COLD-BTP;Database=InventoryManagement;Integrated Security=True;Trust Server Certificate=true";

            var connection = new SqlConnection(CONNECTION_STRING);


            connection.Open();

            var repositorySupplier = new SupplierRepository(connection);
            var repositoryProduct = new Repository<Product>(connection);

            var prd = repositoryProduct.Get(3);
            var sup = repositorySupplier.Get(2);

            Sales.SupplierHasProduct(connection, sup, prd);




            connection.Close();
             




        }
    }
}
