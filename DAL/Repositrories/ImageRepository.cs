using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositrories
{
    public class ImageRepository<Image> : IImageRepository<Image>
    {
        public void Upload(IFormFile file)
        {

        }
    }
}
