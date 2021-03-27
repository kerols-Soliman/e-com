using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Cart")]
    public class Cart
    {

        [ForeignKey("User")]
        [Key]
        public string User_Id { get; set; }
        public virtual ApplicationUserIdentity User { get; set; }

        public virtual List<ProductCart> ProductsCart { get; set; }
       
        //public virtual List<Order> Order { get; set; }
    }
}
