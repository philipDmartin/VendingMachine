using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using VendingMachineCsharp.Data;
using VendingMachineCsharp.Repositories;
using VendingMachineCsharp;

namespace VendingMachineCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseTransactionsController : ControllerBase
    {
        private readonly PurchaseTransactionsRepository _purchaseTransactionsRepository;

        public PurchaseTransactionsController(ApplicationDbContext context)
        {
            _purchaseTransactionsRepository = new PurchaseTransactionsRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_purchaseTransactionsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var purchaseTransactions = _purchaseTransactionsRepository.GetById(id);
            if (purchaseTransactions == null)
            {
                return NotFound();
            }
            return Ok(purchaseTransactions);
        }
    }
}
