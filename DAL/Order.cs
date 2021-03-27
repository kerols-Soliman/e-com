using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string User_Id { get; set; }

        public virtual ApplicationUserIdentity User { get; set; }

        public List<ProductOrder> productOrders { get; set; }

        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
    }
}
