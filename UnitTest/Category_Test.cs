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
    public class Category_Test
    {
        CategroyAppService categroyAppService;
        [SetUp]
        public void Initial()
        {
            categroyAppService = new CategroyAppService();
        }
        [Test]
        public void GetAllTest()
        {
            var result = categroyAppService.GetAllCategroy().Count();
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetByIdTest()
        {
            var result = categroyAppService.GetCategroyById(10);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetById_CheckHisName()
        {
            var result = categroyAppService.GetCategroyById(1);
            Assert.That(result.Name, Is.EqualTo("Labtop"));
        }

        [Test]
        public void GetById_CheckHisProductNumber()
        {
            var result = categroyAppService.GetCategroyById(1);
            Assert.That(result.Products.Count(), Is.EqualTo(6));
        }

        [Test]
        public void InsertCategory_Test()
        {
            CategroyViewModel categroy = new CategroyViewModel();
            categroy.Name = "Cloth";
            var result = categroyAppService.SaveNewCategroy(categroy);
            Assert.That(result, Is.True);
        }

        [Test]
        public void InsertExitingCategory()
        {
            CategroyViewModel categroy = new CategroyViewModel();
            categroy.Name = "Cloth";
            categroy.Id = 5;
            var result = categroyAppService.SaveNewCategroy(categroy);
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateCategory()
        {
            CategroyViewModel categroy = new CategroyViewModel { Id = 5, Name = "clothes" };
            var result= categroyAppService.UpdateCategroy(categroy);
            Assert.That(result, Is.True);
        }

        
        [Test]
        public void DeleteCategroyExist()
        {
            var res = categroyAppService.DeleteCategroy(5);
            Assert.That(res, Is.True);
        }

        [Test]
        public void DeleteCategroyNotExist()
        {
            var res = categroyAppService.DeleteCategroy(70);
            Assert.That(res, Is.False);
        }

        [Test]
        public void CheckCategoryExists_Test()
        {
            var res=categroyAppService.CheckCategoryExists(new CategroyViewModel { Name = "Labtop",Id=1 });
            Assert.That(res, Is.True);
        }
        [Test]
        public void CheckCategoryNotExists_Test()
        {
            var res = categroyAppService.CheckCategoryExists(new CategroyViewModel { Name = "Labtop2", Id = 4 });
            Assert.That(res, Is.False);
        }
    }
}
