using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    Name = "Show Off Item " + j,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus pretium orci et libero gravida vestibulum. Phasellus in libero neque. Integer a metus at magna suscipit suscipit. Nulla facilisi.",
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

        public static void ExecuteSqlScript(string sql)
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShowOffConnectionString"].ConnectionString))
            {
                connection.Open();

                Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string[] lines = regex.Split(sql);

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.Connection = connection;
                    
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            cmd.CommandText = line;
                            cmd.CommandType = CommandType.Text;

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                throw;
                            }
                        }
                    }
                }

                connection.Close();
            }
        }

        public static void ExecuteMigrations(System.Web.HttpServerUtilityBase server)
        {
            DirectoryInfo di = new DirectoryInfo(server.MapPath("~\\Migrations"));
            
            FileInfo[] fi = di.GetFiles("*.sql", SearchOption.TopDirectoryOnly);

            var alphaFiles = fi.OrderBy(p => p.Name);

            StringBuilder sb = new StringBuilder();

            foreach (FileInfo fii in alphaFiles)
            {
                TextReader tr = new StreamReader(fii.FullName);

                sb.Append(tr.ReadToEnd());

                tr.Close();

                ExecuteSqlScript(sb.ToString());

                sb = new StringBuilder();
            }
        }
    }
}