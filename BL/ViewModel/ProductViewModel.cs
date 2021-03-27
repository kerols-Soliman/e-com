using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(4)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quentity { get; set; }


        [Required, MinLength(10)]
        public string Description { get; set; }



        [Required]
        public string Image { get; set; }
        public int Discount { get; set; }
        [Display(Name="Category Name")]
        public int Category_Id { get; set; }

    }
}
