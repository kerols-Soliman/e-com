using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FavoriteProduct
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string User_Id { get; set; }
        public virtual ApplicationUserIdentity User { get; set; }


        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public virtual Product Product { set; get; }
    }
}
