using BL.AppServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class Cart_Test
    {
        CartAppService cartApp;
        [SetUp]
        public void Initial()
        {
            cartApp = new CartAppService();
        }

        [Test]
        public void GetCartById_NotExist()
        {
            var res = cartApp.GetById("notUser");
            Assert.That(res, Is.Null);
        }

        [Test]
        public void GetCartById_Exist()
        {
            var res = cartApp.GetById("054f763a-0cd5-40bd-a440-ef103068ec9e");
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public void addNewProduct()
        {
            var res = cartApp.SaveNewProductToCart(1, 2, "054f763a-0cd5-40bd-a440-ef103068ec9e");
            Assert.That(res, Is.True);
        }

        [Test]
        public void deleteCart()
        {
            cartApp.Delete("054f763a-0cd5-40bd-a440-ef103068ec9e");
            var res = cartApp.GetById("054f763a-0cd5-40bd-a440-ef103068ec9e").ProductsCart.Where(x=>x.Cart_Id== "054f763a-0cd5-40bd-a440-ef103068ec9e").FirstOrDefault();
            Assert.That(res, Is.Null);
        }
    }
}
