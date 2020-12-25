using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VendingMachineCsharp.Data;
using VendingMachineCsharp;

namespace VendingMachineCsharp.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        } 

        public Product GetById(int id)
        {
            return _context.Product.FirstOrDefault(p => p.Id == id);
        }
    }
}
