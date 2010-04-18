using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Data.Linq;
using NUnit.Framework;
using ShowOff.Core.Data;
using ShowOff.Core.Model;
using ShowOff.Core.Repository;

namespace ShowOff.IntegrationTests.Data
{
    [TestFixture]
    public class DataTests
    {
        public DataTests()
        {
            
        }
        
        [SetUp]
        public static void SetupDatabase()
        {
            SessionFactoryFactory.DropSchema();
            SessionFactoryFactory.CreateSchema();  
        }

        [Test]
        public void CreateData()
        {
            var session = SessionFactoryFactory.GetSessionFactory().OpenSession();

            // item types
            var websiteItemType = new ItemType() {ID = 1, Name = "Website", DisplayName = "Website"};
            var logoItemType = new ItemType() { ID = 2, Name = "Logo", DisplayName = "Logo" };
            var printItemType = new ItemType() { ID = 3, Name = "Print", DisplayName = "Print" };
            var apparelItemType = new ItemType() { ID = 4, Name = "Apparel", DisplayName = "Apparel" };

            session.SaveOrUpdate(websiteItemType);
            session.SaveOrUpdate(logoItemType);
            session.SaveOrUpdate(printItemType);
            session.SaveOrUpdate(apparelItemType);

            for (int j = 0; j < 10; j++)
            {
                // item images
                var itemImageRepo = new ItemImageRepository();

                var fileNames = new List<string>()
                                    {
                                        "test1.jpg",
                                        "test2.jpg",
                                        "test3.jpg",
                                        "test4.jpg",
                                        "test5.jpg"
                                    };


                var images = fileNames.Select(p => new ItemImage() {Filename = p, ThumbFilename = p}).ToList();
                
                var item = new Item()
                               {
                                   Name = "ShowOff Item " + j,
                                   Description = "Show me off to the world.",
                                   Url = "http://www.showoffgallery.com",
                                   CreatedDate = DateTime.Now,
                                   ModifiedDate = DateTime.Now,
                                   Type = websiteItemType,
                                   Images = images,
                                   CoverImage = images[0],
                                   DisplayPriority = 0
                               };

                session.SaveOrUpdate(item);
                session.Flush();
            }
        }

        [Test]
        public void UpdateData()
        {
        }

        [Test]
        public void DeleteData()
        {
        }
    }
}