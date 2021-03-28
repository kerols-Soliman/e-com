using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class OrderAppServices:AppServiceBase
    {
        public List<Order> GetAllOrder()
        {
            return TheUnitOfWork.Order.GetAll();
        }
        public List<Order> GetMyOder(string userId)
        {
            return TheUnitOfWork.Order.GetAllOrderRelatedToUser(userId);
        }
        public bool InsertProductToOrder(Cart cart)
        {
            List<ProductOrder> productOrderList = new List<ProductOrder>();
            ProductOrder productOrder;
            double totalPrice = 0;
            Order Order = new Order();
            
            Order.User_Id = cart.User_Id;
            Order.Date = DateTime.Now;
            Order.productOrders = productOrderList;
            Order.TotalPrice = totalPrice;
            

            foreach (var item in cart.ProductsCart)
            {
                productOrder = new ProductOrder();
                productOrder.Product_Id = item.Product_Id;
                productOrder.Quntaty = item.Quntity;
                //productOrder.Product = item.Product;
                // productOrder.Order = Order;
                productOrder.Order_Id = Order.Id;
                    productOrderList.Add(productOrder);
                //TheUnitOfWork.ProductOrder.Insert(productOrder);
                totalPrice += item.Quntity * item.Product.Price;
                
            }


            Order.TotalPrice = totalPrice;
            bool result = false;
            if (TheUnitOfWork.Order.Insert(Order))
            { 
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;

        }
    }
}
