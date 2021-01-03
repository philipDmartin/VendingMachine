using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp.Repositories
{
    public class InventoryService
    {
        private readonly string _connectionString;
        public InventoryService()
        {
            _connectionString = "server=localhost\\SQLExpress;database=VendingMachine;integrated security=true;";

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
                    cmd.CommandText = @"SELECT
                                               Qty,  
                                               p.[Name] AS ProductName,
                                               VendingMachineId
                                        FROM Inventory i
                                        JOIN Product p ON p.Id = i.Id;";

                    var reader = cmd.ExecuteReader();
                    var types = new List<Inventory>();
                    while (reader.Read())
                    {
                        var type = new Inventory()
                        {
                            //Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                            Product = new Product
                            {
                                Name = reader.GetString(reader.GetOrdinal("ProductName"))
                            },
                            VendingMachineId = reader.GetInt32(reader.GetOrdinal("VendingMachineId"))
                        };
                        types.Add(type);
                    }

                    reader.Close();

                    return types;
                }
            }
        }

        public void Update(Inventory type)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Inventory 
                           SET Qty = @qty, 
                               Product = @product
                               VendingMachineId = @vendingMachineId
                         WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@qty", type.Qty);
                    cmd.Parameters.AddWithValue("@product", type.Product);
                    cmd.Parameters.AddWithValue("@vendingMachineId", type.VendingMachineId);

                    cmd.ExecuteNonQuery();
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
