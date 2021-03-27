using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationUserIdentity : IdentityUser
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Gender { get; set; }

        public virtual Cart Cart { set; get; }
        public virtual List<FavoriteProduct> FavoriteProducts { get; set; }
        public virtual List<Order> Order { get; set; }
    }
    public class ApplicationUserStore : UserStore<ApplicationUserIdentity>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager()
            : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db)
            : base(new RoleStore<IdentityRole>(db))
        {

        }
    }
    public class ApplicationUserManager : UserManager<ApplicationUserIdentity>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }




    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIdentity>
    {

        public ApplicationDBContext() :
            base("Data Source=.;Initial Catalog=EcoMmce;Integrated Security=True")
        {

        }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<Order> Orders { set; get; }




    }
}
