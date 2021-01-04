using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp.Repositories
{
    public class PurchaseTransactionsService
    {
        private readonly string _connectionString;
        public PurchaseTransactionsService()//IConfiguration configuration)
        {
            _connectionString = "server=localhost\\SQLExpress;database=VendingMachine;integrated security=true;";
        }

        public SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<PurchaseTransactions> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
                                        PurchaseTotal, 
                                        PurchaseQty, 
                                        Time, 
                                        p.[Name] AS ProductName,
                                        v.[Name] AS VendingMachineName 
                                    FROM PurchaseTransactions pt
                                    JOIN Product p ON pt.ProductId = p.Id
                                    JOIN VendingMachine v ON pt.VendingMachineId = v.Id";

                    var reader = cmd.ExecuteReader();
                    var types = new List<PurchaseTransactions>();
                    while (reader.Read())
                    {
                        var type = new PurchaseTransactions()
                        {
                            PurchaseTotal = reader.GetInt32(reader.GetOrdinal("PurchaseTotal")),
                            PurchaseQty = reader.GetInt32(reader.GetOrdinal("PurchaseQty")),
                            Time = reader.GetDateTime(reader.GetOrdinal("Time")),
                            Product = new Product
                            {
                                Name = reader.GetString(reader.GetOrdinal("ProductName"))
                            },
                            VendingMachine = new VendingMachine
                            {
                                Name = reader.GetString(reader.GetOrdinal("VendingMachineName"))
                            },
                        };
                        types.Add(type);
                    }

                    reader.Close();

                    return types;
                }
            }
        }

        public void Update(PurchaseTransactions type)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE PurchaseTransactions 
                           SET PurchaseTotal = @purchaseTotal
                               PurchaseQty = @purchaseQty, 
                               Time = @time
                               ProductId = @productId
                               VendingMachineId = @vendingMachineId
                         WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@PurchaseTotal", type.PurchaseTotal);
                    cmd.Parameters.AddWithValue("@PurchaseQty", type.PurchaseQty);
                    cmd.Parameters.AddWithValue("@Time", type.Time);
                    cmd.Parameters.AddWithValue("@ProductId", type.ProductId);
                    cmd.Parameters.AddWithValue("@vendingMachineId", type.VendingMachineId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Add(PurchaseTransactions type)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO PurchaseTransactions (PurchaseTotal, PurchaseQty, Time, ProductId, VendingMachineId)
                        OUTPUT INSERTED.ID
                        VALUES (@purchaseTotal, @purchaseQty, @time, @productId, @vendingMachineId)";
                    cmd.Parameters.AddWithValue("@purchaseTotal", type.PurchaseTotal);
                    cmd.Parameters.AddWithValue("@purchaseQty", type.PurchaseQty);
                    cmd.Parameters.AddWithValue("@time", type.Time);
                    cmd.Parameters.AddWithValue("@productId", type.ProductId);
                    cmd.Parameters.AddWithValue("@vendingMachineId", type.VendingMachineId);

                    type.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
