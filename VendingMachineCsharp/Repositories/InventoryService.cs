using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp.Repositories
{
    public class InventoryService
    {
        //Connection to SQL Database
        private readonly string _connectionString;
        public InventoryService()
        {
            _connectionString = "server=localhost\\SQLExpress;database=VendingMachine;integrated security=true;";
        }
        
        public SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        //Get All
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
                                      JOIN Product p ON i.ProductId = p.Id";

                    var reader = cmd.ExecuteReader();
                    var types = new List<Inventory>();
                    while (reader.Read())
                    {
                        var type = new Inventory()
                        {
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

        //Get By Id Controller
        public Inventory Get(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                              Id,
                              Qty,  
                              ProductId,
                              VendingMachineId
                        FROM Inventory i
                        WHERE Id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    Inventory type = null;
                    if (reader.Read())
                    {
                        type = new Inventory()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                            ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                            VendingMachineId = reader.GetInt32(reader.GetOrdinal("VendingMachineId"))
                        };
                    }

                    reader.Close();

                    return type;
                }
            }
        }

        //Update
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
                               ProductId = @productId,
                               VendingMachineId = @vendingMachineId
                         WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", type.Id);
                    cmd.Parameters.AddWithValue("@qty", type.Qty);
                    cmd.Parameters.AddWithValue("@productId", type.ProductId);
                    cmd.Parameters.AddWithValue("@vendingMachineId", type.VendingMachineId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
