using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineCsharp;
using Microsoft.EntityFrameworkCore;

namespace VendingMachineCsharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<PurchaseTransactions> PurchaseTransactions { get; set; }
        public DbSet<VendingMachine> VendingMachine { get; set; }
        //public DbSet<VendingMachineStateEnum> VendingMachineStateEnum { get; set; }
    }
}
