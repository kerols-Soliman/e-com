using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class FavoriteProductAppService:AppServiceBase
    {
        public bool SaveNewProductToFaviorate(int product_id, string user_ID)
        {
            bool result = false;
            var product = TheUnitOfWork.FavoriteProduct.GetWhere(p => p.User_Id == user_ID && p.Product_Id == product_id).FirstOrDefault();
            if (product != null)
            {
                return result;
            }

            FavoriteProduct NewFavorateProduct = new FavoriteProduct { User_Id = user_ID, Product_Id = product_id };

            if (TheUnitOfWork.FavoriteProduct.Insert(NewFavorateProduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public List<Product> GetProductsINFaviorate(string user_ID)
        {
            var Faviorate_Product = TheUnitOfWork.FavoriteProduct.GetWhere(FP => FP.User_Id == user_ID).ToList();
            List<Product> newList = new List<Product>();
            foreach (var item in Faviorate_Product)
            {
                newList.Add(TheUnitOfWork.Product.GetById(item.Product_Id));
            }
            return newList;
        }

        public bool DeleteProductFromFaviorate(int id)
        {
            bool result = false;
            var FP = TheUnitOfWork.FavoriteProduct.GetWhere(p => p.Product_Id == id).FirstOrDefault();
            TheUnitOfWork.FavoriteProduct.Delete(FP.Id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
    }
}
