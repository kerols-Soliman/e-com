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
    public class CategroyAppService : AppServiceBase
    {
        public List<CategroyViewModel> GetAllCategroy()
        {
            return Mapper.Map<List<CategroyViewModel>>(TheUnitOfWork.Category.GetAll());
        }

        public CategroyViewModel GetCategroyById(int id)
        {
            return Mapper.Map<CategroyViewModel>(TheUnitOfWork.Category.GetById(id));
        }

        //insert
        public bool SaveNewCategroy(CategroyViewModel categroyViewModel)
        {
            bool result = false;
            CategroyViewModel CatVM=this.GetAllCategroy().Where(c => c.Name == categroyViewModel.Name).FirstOrDefault();

            if (CatVM !=null)
            {
                return result;
            }
            var category = Mapper.Map<Category>(categroyViewModel);

            if (TheUnitOfWork.Category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }




        public bool UpdateCategroy(CategroyViewModel categroyViewModel)
        {
            var category = Mapper.Map<Category>(categroyViewModel);
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool DeleteCategroy(int id)
        {
            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }



        public bool CheckCategoryExists(CategroyViewModel categroyViewModel)
        {
            Category category = Mapper.Map<Category>(categroyViewModel);
            return TheUnitOfWork.Category.CheckCategroyExists(category);
        }

        public List<ProductViewModel> GetProductsInCategory(int Categ_id)
        {
            return Mapper.Map<List<ProductViewModel>>(TheUnitOfWork.Product.GetWhere(p => p.Category_Id == Categ_id));
        }
    }
}
