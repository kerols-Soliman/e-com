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
    public class ProductCartRepositry : BaseRepositry<ProductCart>
    {

        private DbContext EC_DbContext;
        public ProductCartRepositry(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }
        public List<ProductCart> GetAll()
        {
            return base.GetAll().Include(x => x.Product).ToList();
        }

        public ProductCart GetById(int id)
        {
            return dbset.Where(x => x.Id == id).Include(x => x.Product).FirstOrDefault();
            //return base.GetById(id).Include(x => x.Product).ToList();
        }
        
    }
}
