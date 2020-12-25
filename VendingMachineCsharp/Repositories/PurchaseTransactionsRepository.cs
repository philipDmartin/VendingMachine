using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VendingMachineCsharp.Data;
using VendingMachineCsharp;

namespace VendingMachineCsharp.Repositories
{
    public class PurchaseTransactionsRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseTransactionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PurchaseTransactions> GetAll()
        {
            return _context.PurchaseTransactions.ToList();
        }

        public PurchaseTransactions GetById(int id)
        {
            return _context.PurchaseTransactions.FirstOrDefault(p => p.Id == id);
        }
    }
}
