using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AsianGoodiesWithUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly DataContext _context;

        public ImageController(IHostEnvironment hostingEnv , DataContext context)
        {
            _hostingEnvironment = hostingEnv;
            _context = context;
        }
        [HttpGet("GetAll")]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost("UploadImage")]
        public ActionResult<string> UploadImage()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newFileName = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                        var path = Path.Combine("", _hostingEnvironment.ContentRootPath + "\\Images\\" + newFileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        Image imageUpload = new Image();
                        imageUpload.ImagePath = path;
                        imageUpload.InsertedOn = DateTime.Now;
                        _context.Images.Add(imageUpload);
                        _context.SaveChanges();

                    }
                    return "saved successfully";
                }
                else
                    return "select a file";


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //[HttpPost("fileUpload")]
        //public IActionResult Upload(IFormFile file)
        //{
        //    return Ok();
        //}
    }
}
