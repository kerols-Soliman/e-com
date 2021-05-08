using BL.AppServices;
using BL.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class Product_Test
    {
        ProductAppService productAppService;
        [SetUp]
        public void Initial()
        {
            productAppService = new ProductAppService();
        }

        [Test]
        public void GetTotal_Products_Numbers_Test()
        {
            var result = productAppService.GetAllProduct().Count();
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Get_Product_ById_Test()
        {
            var result = productAppService.GetProductByID(2);
            Assert.That(result.Name, Is.EqualTo("Dell 500"));
        }



        [Test]
        public void Get_Product_Price_Test()
        {
            var result = productAppService.GetProductByID(1);
            Assert.That(result.Price, Is.EqualTo(7000));
        }

        [Test]
        public void Get_Product_Quantity()
        {
            var result = productAppService.GetProductByID(1);
            Assert.That(result.Quentity, Is.EqualTo(5));
        }



        [Test]
        public void Remove_Product_Test()
        {
            var result = productAppService.DeleteProduct(9);
            Assert.That(result, Is.EqualTo(true));
        }



        [Test]
        public void Add_New_Product_Test()
        {
            var product = new ProductViewModel()
            {
                Name = "apple LabTop",
                Price = 120000,
                Quentity = 8,
                Description = "Apple product",
                Image = "1.jbg",
                Category_Id = 1
            };
            var result = productAppService.SaveNewProduct(product);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void Check_Product_Avablity_Test()
        {
            var product = new ProductViewModel()
            {
                Name = "NewOne",
                Price = 15000,
                Quentity = 11,
                Description = "Test Only",
                Image = "2.jbg",
                Category_Id = 1
            };
            var result = productAppService.CheckProductExists(product);
            Assert.That(result, Is.EqualTo(false));
        }

    }
}
