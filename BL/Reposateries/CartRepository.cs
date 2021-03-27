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
    public class CartRepository : BaseRepositry<Cart>
    {
        private DbContext EC_DbContext;
        public CartRepository(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }
        public virtual Cart GetById(string entityId)
        {

            return dbset.Where(x=>x.User_Id == entityId).Include(n=>n.ProductsCart.Select(x=>x.Product)).FirstOrDefault();
        }
        //public List<ProductCart> GetProductsInCart(string id)
        //{
        //    Cart cart = GetById(id);
        //    List<ProductCart> productInCart = new List<ProductCart>();
        //    foreach (var item in cart.ProductsCart)
        //    {
        //        productInCart.Add(item);
        //    }
        //    return productInCart;
        //}
    }
}
