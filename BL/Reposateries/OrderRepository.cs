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
        public List<Order> GetAll()
        {
            return base.GetAll().Include(x => x.productOrders.Select(c => c.Product)).ToList();
        }
        public List<Order> GetById(string userId)
        {
            return dbset.Where(x => x.User_Id == userId).Include(x => x.productOrders.Select(n => n.Product)).ToList();
        }
        public List<Order> GetAllOrderRelatedToUser(string userId)
        {
            return GetById(userId);
        }
    }
}
