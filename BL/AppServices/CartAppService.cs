using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class CartAppService: AppServiceBase
    {
        public Cart GetById(string user_id)
        {
            return(TheUnitOfWork.Cart.GetById(user_id));
        }
        public bool SaveNewProductToCart(int Product_id, int Quentity, string user_ID)
        {
            var Checkcart = TheUnitOfWork.Cart.GetById(user_ID);
            if (Checkcart == null)
            {
                Cart cart = new Cart { User_Id = user_ID };
                if (TheUnitOfWork.Cart.Insert(cart))
                {
                    TheUnitOfWork.Commit();
                }
            }
            bool result = false;
            var productInCart = TheUnitOfWork.ProductCart.GetWhere(p => p.Cart_Id == user_ID && p.Product_Id == Product_id).FirstOrDefault();
            if (productInCart != null)
            {
                productInCart.Quntity += Quentity;
                TheUnitOfWork.ProductCart.Update(productInCart);
                TheUnitOfWork.Commit();
                return result;
            }
            else
            {
                var product= TheUnitOfWork.Product.GetById(Product_id);
                ProductCart pro_cart = new ProductCart { Cart_Id = user_ID, Product_Id = Product_id, Quntity = Quentity ,Product= product };



                //var product = Mapper.Map<Product>(productViewModel);
                if (TheUnitOfWork.ProductCart.Insert(pro_cart))
                {
                    result = TheUnitOfWork.Commit() > new int();
                }
                return result;
            }
            
        }

        //public List<ProductCart> GetProductsINCart(string user_ID)
        //{
        //    var product_Cart = TheUnitOfWork.ProductCart.GetWhere(pc => pc.Cart_Id == user_ID).ToList();

        //    List<Product> newList = new List<Product>();
        //    foreach (var item in product_Cart)
        //    {
        //        newList.Add(TheUnitOfWork.Product.GetById(item.Product_Id));
        //    }



        //    return newList;
        //    //var product = Mapper.Map<Product>(productViewModel);

        //}
        //public List<ProductCart> GetProductsINCart(string user_ID)
        //{
        //    var product_Cart = TheUnitOfWork.Cart.GetProductsInCart(user_ID);
        //    return product_Cart;
        //}
    }
}
