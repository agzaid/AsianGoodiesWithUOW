using BLL;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AsianGoodiesWithUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IHostEnvironment _env { get; }

        // private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork, IHostEnvironment env)
        {
            _env = env;
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
        [HttpPost("SingleFile")]
        public IActionResult SingleFile([FromForm] User user)
        {
            var dir = _env.ContentRootPath;

            User user1 = new User();
            var files = HttpContext.Request.Form.Files;
            if (files!=null && files.Count>0)
            {
                foreach (var item in files)
                {
                    FileInfo fi = new FileInfo(item.FileName);
                    var fileName = item.FileName.Split(".");
                    var newFileName = fileName[0]+"_" + DateTime.Now.TimeOfDay.Days + fi.Extension;
                    var path = Path.Combine("", dir + "\\Images\\" + newFileName);
                    using (var fileStream = new FileStream(path , FileMode.Create))
                    {
                        item.CopyTo(fileStream);
                    }
                    user1.ImageName = newFileName;
                    user1.firstName = user.firstName;
                    user1.LastName = user.LastName;
                    user1.InsertedOn = DateTime.Now;
                }
            }
            _unitOfWork.Users.Add(user1);
            _unitOfWork.Complete();

            return Ok(user1);
        }

        [HttpPost("MultipleFiles")]
        public IActionResult MultipleFiles(SomeForm someForm)
        {
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    file.CopyTo(fileStream);
            //}

            return Ok();
        }
    }
}
