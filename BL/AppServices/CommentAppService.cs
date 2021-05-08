using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class CommentAppService : AppServiceBase
    {
        public bool InsertComment(string user_ID,int product_id, string commentText)
        {
            bool result = false;
            
            if (TheUnitOfWork.Comment.InsertCommit(user_ID,product_id,commentText))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public List<Comment> GetAllComment(int productId)
        {
            return TheUnitOfWork.Comment.GetAll(productId);
        }
    }
}
