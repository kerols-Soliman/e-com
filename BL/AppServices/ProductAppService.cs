using BL.Bases;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ProductAppService : AppServiceBase
    {
        public List<ProductViewModel> GetAllProduct()
        {
            return Mapper.Map<List<ProductViewModel>>(TheUnitOfWork.Product.GetAll());
        }

        public ProductViewModel GetProductByID(int id)
        {
            return Mapper.Map<ProductViewModel>(TheUnitOfWork.Product.GetById(id));
        }

        //insert
        public bool SaveNewProduct(ProductViewModel productViewModel)
        {
            bool result = false;
            var product = Mapper.Map<Product>(productViewModel);
            if (TheUnitOfWork.Product.Insert(product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }




        public bool UpdateProduct(ProductViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);
            TheUnitOfWork.Product.Update(product);
            TheUnitOfWork.Commit();
            return true;
        }






        public bool DeleteProduct(int id)
        {
            bool result = false;

            TheUnitOfWork.Product.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }



        public bool CheckProductExists(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel);
            return TheUnitOfWork.Product.CheckProductExists(product);
        }
    }
}
