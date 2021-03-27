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
    public class CategoryRepository : BaseRepositry<Category>
    {
        private DbContext EC_DbContext;
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return base.GetAll().Include(p=>p.Products).ToList();
        }
        public override Category GetById(int entityId)
        {
            return dbset.Find(entityId);
        }
        public bool CheckCategroyExists(Category category)
        {
            return GetAny(c => c.Id == category.Id);
        }
    }
}
