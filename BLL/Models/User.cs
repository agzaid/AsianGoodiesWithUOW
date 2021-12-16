using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string firstName { get; set; }
        public string LastName { get; set; }
        public List<Product> Products { get; set; }

    }
}
