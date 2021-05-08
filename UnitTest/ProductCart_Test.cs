using BL.AppServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class ProductCart_Test
    {
        ProductCartAppService productCartAppService;
        [SetUp]
        public void Initial()
        {
            productCartAppService = new ProductCartAppService();
        }

        [Test]
        public void Get_Product_ById_Test()
        {
            var result = productCartAppService.GetById(22);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Check_Cart_Products_Quantity_Test()
        {
            var result = productCartAppService.GetById(22).Quntity;
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Check_Cart_Products_Update()
        {

            var prodctCart = productCartAppService.GetById(22);
            prodctCart.Quntity = 20;
            var result = productCartAppService.UpdateProductCart(prodctCart);
            Assert.That(result, Is.EqualTo(true));
        }



        [Test]
        public void Check_Cart_Has_Specifec_Product_Test()
        {
            string productName = "Lenovo Ideapad 500";
            var result = productCartAppService.GetById(22).Product.Name;

            Assert.That(result, Is.EqualTo(productName));
        }



    }
}
