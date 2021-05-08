using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public string User_Id { set; get; }
        public virtual ApplicationUserIdentity user { set; get; }


        [ForeignKey("product")]
        public int product_Id { get; set; }
        public virtual Product product { get; set; }


        public string comment { set; get; }
    }
}
