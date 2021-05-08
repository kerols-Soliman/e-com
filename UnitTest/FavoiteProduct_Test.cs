using BL.AppServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestFixture]
    class FavoiteProduct_Test 
    { 
        FavoriteProductAppService favoriteProductAppService;
        [SetUp]
        public void Intial()
        {
            favoriteProductAppService = new FavoriteProductAppService();
        }
        [Test]
        public void SaveNewProductToFaviorate_test()
        {
            bool result = favoriteProductAppService.SaveNewProductToFaviorate(3, "ec576786-9341-49eb-abee-b71993f57d9e");
            Assert.That(result, Is.EqualTo(true));
        }


        [Test]
        public void GetProductsINFaviorate_test()
        {
            var result = favoriteProductAppService.GetProductsINFaviorate("ec576786-9341-49eb-abee-b71993f57d9e").Count();
            Assert.That(result, Is.EqualTo(2));
        }


        [Test]
        public void DeleteProductFromFaviorate_test()
        {
            var result = favoriteProductAppService.DeleteProductFromFaviorate(3);
            Assert.That(result, Is.True);
        }



    }
}
