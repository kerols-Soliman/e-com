using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reposateries
{
   public class ProductOrderRepositry : BaseRepositry<ProductOrder>
    {
        private DbContext EC_DbContext;
        public ProductOrderRepositry(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }
        public List<ProductOrder> GetAll()
        {
            return base.GetAll().ToList();
        }

    }
}
