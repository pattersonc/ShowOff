using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShowOff.Core.Model;
using ShowOff.Core.Repository;

namespace ShowOff.Core.Data
{
    public static class SetupHelper
    {
        public static void ResetDatabase()
        {
            SessionFactoryFactory.DropSchema();
            SessionFactoryFactory.CreateSchema();
        }

        public static void AddDefaultData()
        {
            var session = SessionFactoryFactory.GetSessionFactory().OpenSession();

            // item types
            var websiteItemType = new ItemType() { ID = 1, Name = "Website", DisplayName = "Website" };
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


                var images =
                    fileNames.Select(
                        p =>
                        new ItemImage()
                            {
                                Filename = p,
                                ThumbFilename = Path.GetFileNameWithoutExtension(p) + "_thumb" + Path.GetExtension(p)
                            }).
                        ToList();

                var item = new Item()
                {
                    Name = "ShowOff Item " + j,
                    Description = "Show me off to the world.",
                    Url = "http://www.showoffgallery.com",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Type = websiteItemType,
                    Images = images,
                    CoverImage = images[new Random().Next(0, 4)],
                    DisplayPriority = 0
                };

                session.SaveOrUpdate(item);
                session.Flush();

            }
        }
    }
}