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
    [TestFixture]
    class Account_Test
    {
        AccountAppService account;
        [SetUp]
        public void Intial()
        {
            account = new AccountAppService();
        }
        [Test]
        public void Find_userTest()
        {
            var user = account.Find("bahy", "12345678");
            //Assert.That(user.UserName,Does.StartWith("b").And.EndsWith("y"));
            Assert.That(user.Email, Does.Contain("bahy"));
        }

        [Test]
        public void Register_test()
        {
            RegisterViewModel user = new RegisterViewModel { UserName = "Bassam", PasswordHash = "123456789", Email = "Bassam@gmail.com" };
            var result = account.Register(user);
            Assert.That(result.Succeeded, Is.EqualTo(true));//because the user is exist already
        }


        [Test]
        public void AssignToRole_test()
        {
            var result = account.AssignToRole("681d3de9-b4b1-4c5d-8b3d-7d86fbb45447", "Admin");
            Assert.That(result.Succeeded, Is.EqualTo(true));
        }



    }
}
