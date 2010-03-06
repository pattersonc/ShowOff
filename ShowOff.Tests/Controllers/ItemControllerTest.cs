using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShowOff.Controllers;
using ShowOff.Core.Model;
using ShowOff.Core.Repository;

namespace ShowOff.Tests.Controllers
{
    [TestClass]
    public class ItemControllerTest
    {
        private static List<Item> testData;

        public ItemControllerTest()
        {
            testData = GetTestData();
        }

        private static List<Item> GetTestData()
        {
            var result = new List<Item>();

            // item types
            var itemTypes = new List<ItemType>()
                                {
                                    new ItemType() {ID = 1, Name = "Website", DisplayName = "Website"},
                                    new ItemType() {ID = 2, Name = "Logo", DisplayName = "Logo"},
                                    new ItemType() {ID = 3, Name = "Print", DisplayName = "Print"},
                                    new ItemType() {ID = 4, Name = "Apparel", DisplayName = "Apparel"}
                                };


            for (int j = 0; j < 10; j++)
            {
                // item images
                var fileNames = new List<string>()
                                    {
                                        "test1.jpg",
                                        "test2.jpg",
                                        "test3.jpg",
                                        "test4.jpg",
                                        "test5.jpg"
                                    };


                var images = fileNames.Select(p => new ItemImage() { Filename = p, ThumbFilename = p }).ToList();

                var item = new Item()
                {
                    ID = j + 1,
                    Name = "ShowOff Item " + j,
                    Description = "Show me off to the world.",
                    Url = "http://www.showoffgallery.com",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Type = itemTypes[j % itemTypes.Count],
                    Images = images,
                    CoverImage = images[j % images.Count],
                    DisplayPriority = 0
                };

                result.Add(item);
            }

            return result;
        }

        [TestMethod]
        public void Index_Returns_View()
        {
            var mockItemRepo = new Mock<IItemRepository>();
            var mockItemTypeRepo = new Mock<IItemTypeRepository>();
            var mockItemImageRepo = new Mock<IItemImageRepository>();

            var itemController = new ItemController(mockItemRepo.Object, mockItemTypeRepo.Object, mockItemImageRepo.Object);

            var result = itemController.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_Returns_Data_To_View()
        {
            var mockItemRepo = new Mock<IItemRepository>();
            var mockItemTypeRepo = new Mock<IItemTypeRepository>();
            var mockItemImageRepo = new Mock<IItemImageRepository>();

            mockItemRepo.Setup(p => p.GetAll()).Returns(testData);

            var itemController = new ItemController(mockItemRepo.Object, mockItemTypeRepo.Object, mockItemImageRepo.Object);

            var result = itemController.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult) result;
            var model = (IList<Item>) viewResult.ViewData.Model;

            Assert.AreEqual(testData.Count, model.Count);
        }

        [TestMethod]
        public void Details_Returns_View()
        {
            var mockItemRepo = new Mock<IItemRepository>();
            var mockItemTypeRepo = new Mock<IItemTypeRepository>();
            var mockItemImageRepo = new Mock<IItemImageRepository>();

            mockItemRepo.Setup(p => p.GetById(It.IsAny<int>())).Returns<int>( i => testData.Where(p => p.ID == i).Single() );

            var itemController = new ItemController(mockItemRepo.Object, mockItemTypeRepo.Object, mockItemImageRepo.Object);

            var result = itemController.Details(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_Returns_Correct_Data_To_View_Different_ID()
        {
            int id = 1;
            var mockItemRepo = new Mock<IItemRepository>();
            var mockItemTypeRepo = new Mock<IItemTypeRepository>();
            var mockItemImageRepo = new Mock<IItemImageRepository>();

            mockItemRepo.Setup(p => p.GetById(It.IsAny<int>())).Returns<int>( i => testData.Where(p => p.ID == i).Single() );

            var itemController = new ItemController(mockItemRepo.Object, mockItemTypeRepo.Object, mockItemImageRepo.Object);

            var result = itemController.Details(id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            var model = (Item)viewResult.ViewData.Model;

            Assert.AreNotEqual(model, mockItemRepo.Object.GetById(2));
        }

        [TestMethod]
        public void Details_Returns_Correct_Data_To_View_Same_ID()
        {
            int id = 1;
            var mockItemRepo = new Mock<IItemRepository>();
            var mockItemTypeRepo = new Mock<IItemTypeRepository>();
            var mockItemImageRepo = new Mock<IItemImageRepository>();

            mockItemRepo.Setup(p => p.GetById(It.IsAny<int>())).Returns<int>(i => testData.Where(p => p.ID == i).Single());

            var itemController = new ItemController(mockItemRepo.Object, mockItemTypeRepo.Object, mockItemImageRepo.Object);

            var result = itemController.Details(id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            var model = (Item)viewResult.ViewData.Model;

            Assert.AreEqual(model, mockItemRepo.Object.GetById(id));
        }

    }
}