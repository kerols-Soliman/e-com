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
    public class FavoriteProductRepositry : BaseRepositry<FavoriteProduct>
    {
        private DbContext EC_DbContext;
        public FavoriteProductRepositry(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }
        public List<FavoriteProduct> GetAll()
        {
            return base.GetAll().ToList();
        }
    }
}
