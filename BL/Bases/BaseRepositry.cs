using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class BaseRepositry<T> : IRepositry<T> where T : class
    {
        protected DbContext dbContext { set; get; }
        protected DbSet<T> dbset { get; set; }
        public BaseRepositry(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext Is Null");
            }
            this.dbContext = dbContext;
            dbset = this.dbContext.Set<T>();
        }
        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                dbset.Attach(entity);
                dbset.Remove(entity);
            }
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public IQueryable<T> GetAll()
        {
            return dbset;
        }

        public virtual T GetById(int entityId)
        {
            return dbset.Find(entityId);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query;
        }

        public IQueryable<T> GetAllSorted<TKey>(Expression<Func<T, TKey>> sortingExpression)
        {
            return dbset.OrderBy<T, TKey>(sortingExpression);
        }

        public bool GetAny(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbset;
            bool result = false;
            if (filter != null)
            {
                result = query.Any(filter);
            }
            return result;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return dbset.FirstOrDefault(filter);
            }
            return null;
        }

        public bool Insert(T entity)
        {
            bool returnVal = false;
            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                dbset.Add(entity);
            }
            returnVal = true;
            return returnVal;
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
