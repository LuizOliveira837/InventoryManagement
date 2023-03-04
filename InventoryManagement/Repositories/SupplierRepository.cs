using Dapper;
using InventoryManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repositories
{
    public class SupplierRepository : Repository<Supplier>
    {
        SqlConnection _connection;

        public SupplierRepository(SqlConnection connection) : base(connection)
             =>   this._connection = connection;

        public Supplier GetSupplierProducts(int id)
        {

            var sql = @"SELECT	S.*,P.*
                                    FROM		Supplier S
                                    LEFT
                                        JOIN	SupplierProducts SP
                                        ON		S.id = SP.supplierid
                                    LEFT
                                        JOIN	Product P
                                        ON		P.Id = SP.productid
                                    ";

            IList<Supplier> supliers = new List<Supplier>();


            var supplierProducts = _connection.Query<Supplier, Product, Supplier>(
                sql,
                (supplier, product) =>
                {
                    var sup = supliers.FirstOrDefault<Supplier>(s => s.Id == supplier.Id);

                    if(sup == null)
                    {
                        supliers.Add(supplier);
                        supplier.Products.Add(product);
                    }
                    else sup.Products.Add(product);
                       

                    return supplier;

                }, splitOn: "id");

                
            return supliers.FirstOrDefault<Supplier>(supplier=> supplier.Id == id);

        }

        public void AddProduct(Supplier supplier ,Product product, int quantity)
        {


            var sql = @"INSERT INTO SupplierProducts (
                        supplierid
                        ,productid
                        ,quantity
                        ) values(
                         @supplierid
                        ,@productid
                        ,@quantity
                        )";

            var rows = _connection.Execute(sql, new
            {
                supplierid = supplier.Id,
                productid = product.Id,
                quantity = quantity
            });



        }


    }
}
