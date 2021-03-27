using BL.Reposateries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        OrderRepository Order { get; }
        RoleRepository Role { get; }
        ProductRepositry Product { get; }
        CategoryRepository Category { get; }
        AccountRepositry Account { get; }
        CartRepository Cart { get; }
        FavoriteProductRepositry FavoriteProduct { get; }
        ProductCartRepositry ProductCart { get; }
        ProductOrderRepositry ProductOrder { get; }

    }
}
