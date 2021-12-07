using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();

    }
}
