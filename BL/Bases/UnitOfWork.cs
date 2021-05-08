using BL.Interfaces;
using BL.Reposateries;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork:IUnitOfWork
    {
        private DbContext EC_DbContext { get; set; }

        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();
          //  EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
        
        public OrderRepository order;//=> throw new NotImplementedException();
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(EC_DbContext);
                return order;
            }
        }

        public AccountRepositry account;//=> throw new NotImplementedException();
        public AccountRepositry Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepositry(EC_DbContext);
                return account;
            }
        }
        public RoleRepository role;//=> throw new NotImplementedException();
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role= new RoleRepository(EC_DbContext);
                return role;
            }
        }
        public ProductRepositry product;
        public ProductRepositry Product 
        {
            get
            {
                if (product == null)
                    product = new ProductRepositry(EC_DbContext);
                return product;
            }
        }

        public CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if (category == null)
                    category = new CategoryRepository(EC_DbContext);
                return category;
            }
        }
        public CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                if (cart == null)
                    cart = new CartRepository(EC_DbContext);
                return cart;
            }
        }

        public ProductCartRepositry productCart;
        public ProductCartRepositry ProductCart
        {
            get
            {
                if (productCart == null)
                    productCart = new ProductCartRepositry(EC_DbContext);
                return productCart;
            }
        }

        public FavoriteProductRepositry favoriteProduct;
        public FavoriteProductRepositry FavoriteProduct
        {
            get
            {
                if (favoriteProduct == null)
                    favoriteProduct = new FavoriteProductRepositry(EC_DbContext);
                return favoriteProduct;
            }
        }

        public ProductOrderRepositry productOrder;
        public ProductOrderRepositry ProductOrder
        {
            get
            {
                if (productOrder == null)
                    productOrder = new ProductOrderRepositry(EC_DbContext);
                return productOrder;
            }
        }
        public CommentRepositry comment;
        public CommentRepositry Comment
        {
            get
            {
                if (comment == null)
                    comment = new CommentRepositry(EC_DbContext);
                return comment;
            }
        }

    }
}

