using BL.Bases;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class AccountAppService : AppServiceBase
    {
        public ApplicationUserIdentity Find(string username, string password)
        {
            return TheUnitOfWork.Account.Find(username, password);
        }

        public IdentityResult Register(RegisterViewModel user)
        {

            ApplicationUserIdentity userIdentity = Mapper.Map<RegisterViewModel, ApplicationUserIdentity>(user);
            return TheUnitOfWork.Account.Register(userIdentity);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);
        }
    }
}
