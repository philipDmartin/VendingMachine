using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp.Repositories
{
    public class InventoryRepository
    {
        private readonly string _connectionString;
        public InventoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("server=localhost\\SQLExpress;database=VendingMachine;integrated security=true;");
        }

        public SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Inventory> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Qty, ProductId, VendingMachineId 
                                        FROM Inventory";

                    var reader = cmd.ExecuteReader();
                    var types = new List<Inventory>();
                    while (reader.Read())
                    {
                        var type = new Inventory()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                            ProductId = reader.GetInt32(reader.GetOrdinal("BeanVarietyId")),
                            VendingMachineId = reader.GetInt32(reader.GetOrdinal("BeanVarietyId"))
                        };
                        types.Add(type);
                    }

                    reader.Close();

                    return types;
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Inventory WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
