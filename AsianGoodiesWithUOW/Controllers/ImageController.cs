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
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult UploadImage()
        {
            foreach(var file in Request.Form.Files)
            {
                Image img = new Image();
                img.ImageTitle = file.FileName;
            }
            return Ok();
        }
    }
}
