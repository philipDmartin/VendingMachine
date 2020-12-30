using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCsharp.Repositories
{
    public class PurchaseTransactionsRepository
    {
        private readonly string _connectionString;
        public PurchaseTransactionsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("server=localhost\\SQLExpress;database=VendingMachine;integrated security=true;");
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
                    cmd.CommandText = @"SELECT Id, PurchaseTotal, PurchaseQty, Time, ProductId, VendingMachineId 
                                        FROM PurchaseTransactions";

                    var reader = cmd.ExecuteReader();
                    var types = new List<PurchaseTransactions>();
                    while (reader.Read())
                    {
                        var type = new PurchaseTransactions()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            PurchaseTotal = reader.GetInt32(reader.GetOrdinal("PurchaseTotal")),
                            PurchaseQty = reader.GetInt32(reader.GetOrdinal("PurchaseQty")),
                            Time = reader.GetDateTime(reader.GetOrdinal("Time")),
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
