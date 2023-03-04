using Dapper.Contrib.Extensions;
using InventoryManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repositories
{
    public class Repository<T> where T : class
    {
        private SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            this._connection = connection;
        }


        public IEnumerable<T> GetAll()
            =>  this._connection.GetAll<T>();

        public T Get(int id)
            => this._connection.Get<T>(id);

        public void Insert(T model)
            => this._connection.Insert<T>(model);

        public void Delete(int id)
        {
            var model = this._connection.Get<T>(id);

            this._connection.Delete(model);
        }

    }
}
