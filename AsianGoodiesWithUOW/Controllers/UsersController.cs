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
    public class UsersController : ControllerBase
    {
        private readonly IBaseRepository<User> _userRepository;

        public UsersController(IBaseRepository<User> userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetByIdAync(int id)
        {
            return Ok(await _userRepository.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

    }
}
