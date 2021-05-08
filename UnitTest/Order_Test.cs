using BL.AppServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    
    class Order_Test
    {
        OrderAppServices orderApp;
        [SetUp]
        public void initial()
        {
            orderApp = new OrderAppServices();
        }

        [Test]
        public void GetAllOrder_Test()
        {
            var res = orderApp.GetAllOrder();
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public void GetAllOrderCount_Test()
        {
            var res = orderApp.GetAllOrder().Count();
            Assert.That(res, Is.EqualTo(3));
        }

        [Test]
        public void GetMuOrderNotExistUser()
        {
            var res = orderApp.GetMyOder("1234");
            Assert.That(res, Is.Empty);
        }

        [Test]
        public void GetMuOrderExistUser()
        {
            var res = orderApp.GetMyOder("ec576786-9341-49eb-abee-b71993f57d9e");
            Assert.That(res, Is.Not.Empty);
        }
    }
}
