using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VendingMachineCsharp.Data;
using VendingMachineCsharp;

namespace VendingMachineCsharp.Repositories
{
    public class InventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Inventory> GetAll()
        {
            return _context.Inventory.ToList();
        }

        public Inventory GetById(int id)
        {
            return _context.Inventory.FirstOrDefault(p => p.Id == id);
        }
    }
}
