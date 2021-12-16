using BLL;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
       // private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
           // _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("createUser")]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Users.Add(user);
                _unitOfWork.Complete();

                return Ok(user);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.Users.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _unitOfWork.Users.Get(id);
            return Ok(user);
        }
    }
}
