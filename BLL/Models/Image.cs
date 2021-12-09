using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public string ImageData { get; set; }
        public DateTime InsertedOn { get; set; }
        public string ImagePath { get; set; }
        public Product Product { get; set; }
        public int productId { get; set; }
    }
}
