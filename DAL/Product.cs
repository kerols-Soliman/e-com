﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        [Required,MinLength(4)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quentity { get; set; }

        [Required ,MinLength(10)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
        public int Discount { get; set; }

        [ForeignKey("Category")]
        public int Category_Id { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<ProductCart> ProductCarts { get; set; }
        public virtual List<FavoriteProduct> FavoriteProducts { get; set; }

        public virtual List<ProductOrder> productOrders { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
