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
    public class ProductRepositry : BaseRepositry<Product>
    {
        private DbContext EC_DbContext;
        public ProductRepositry(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }
        public List<Product> GetAll()
        {
            return base.GetAll().ToList();
        }

        public bool CheckProductExists(Product product)
        {
            return GetAny(l => l.Id == product.Id);
        }


    }
}
