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
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepository _inventoryRepository;
        public InventoryController(IConfiguration configuration)
        {
            _inventoryRepository = new InventoryRepository(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_inventoryRepository.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _inventoryRepository.Delete(id);
            return NoContent();
        }
    }
}
