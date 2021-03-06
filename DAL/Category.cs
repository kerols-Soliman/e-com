using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
