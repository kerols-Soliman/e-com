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
    public class CommentRepositry: BaseRepositry<Comment>
    {
        private DbContext EC_DbContext;
        public CommentRepositry(DbContext dbContext) : base(dbContext)
        {
            EC_DbContext = dbContext;
        }
        public List<Comment> GetAll(int ProductId)
        {
            return base.GetWhere(x => x.product_Id == ProductId).Include(n=>n.User_Id).ToList();
        }
        public bool InsertCommit(string userId,int ProductId,string commitText)
        {
            Comment Comment = new Comment { product_Id = ProductId, User_Id = userId, comment = commitText };

            return base.Insert(Comment);
        }
    }
}
