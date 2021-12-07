using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsianGoodiesWithUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseRepository<Product> _productRepo;

        public ProductsController(IBaseRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            return Ok(await _productRepo.GetByIdAsync(1));
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName()
        {
            return Ok(await _productRepo.FindAsync(s => s.Name == "salad", new[] { "User" }));
        }
    }
}
