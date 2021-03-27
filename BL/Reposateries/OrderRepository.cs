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
    public class OrderRepository : BaseRepositry<Order>
    {
        private DbContext EC_DbContext;
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }
    }
}
