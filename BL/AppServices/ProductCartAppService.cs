using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ProductCartAppService:AppServiceBase
    {
        public ProductCart GetById(int id)
        {
            return TheUnitOfWork.ProductCart.GetById(id);
        }
        public bool DeleteProductCart(int id)
        {
            bool result = false;
            TheUnitOfWork.ProductCart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool UpdateProductCart(ProductCart productCart)
        {
            TheUnitOfWork.ProductCart.Update(productCart);
            TheUnitOfWork.Commit();
            return true;
        }
    }
}
