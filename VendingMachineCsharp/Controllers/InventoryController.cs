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
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryController(ApplicationDbContext context)
        {
            _inventoryRepository = new InventoryRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_inventoryRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var inventory = _inventoryRepository.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }
    }
}
