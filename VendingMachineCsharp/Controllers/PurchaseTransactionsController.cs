using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineCsharp.Repositories;

namespace VendingMachineCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseTransactionsController : ControllerBase
    {
        private readonly PurchaseTransactionsRepository _purchaseTransactionsRepository;
        public PurchaseTransactionsController(IConfiguration configuration)
        {
            _purchaseTransactionsRepository = new PurchaseTransactionsRepository(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_purchaseTransactionsRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(PurchaseTransactions purchaseTransactions)
        {
            _purchaseTransactionsRepository.Add(purchaseTransactions);
            return CreatedAtAction("Get", new { id = purchaseTransactions.Id }, purchaseTransactions);
        }
    }
}
