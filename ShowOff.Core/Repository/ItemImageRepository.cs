using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ShowOff.Core.Model;
using ShowOff.Core.Util;

namespace ShowOff.Core.Repository
{
    public interface IItemImageRepository
    {
        IList<ItemImage> GetAll();
        ItemImage GetById(int id);
        void Add(ItemImage entity);
        void Add(IList<ItemImage> entities);
        void Update(ItemImage entity);
        void Delete(ItemImage entity);
        void Delete(IList<ItemImage> entities);
        void Save();
        string SaveImageFile(string fileName, Stream inputStream);
        string CreateThumb(string fileName);
    }

    public class ItemImageRepository : NHibernateRepositoryBase<ItemImage>, IItemImageRepository
    {
        public const string RelativePath = "Content\\Uploads\\Images\\";
        public const int ThumbWidthPixels = 200;
        public const int FullWidthPixels = 800;

        private string _storeLocation;

        public ItemImageRepository()
        {
            _storeLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RelativePath);
        }

        public string CreateThumb(string fileName)
        {
            var fileInfo = new FileInfo(fileName);

            if(!fileInfo.Exists)
                throw new FileNotFoundException("Can not create thumb.", fileName);

            string thumbFileName = RandomFilenameHelper.GetRandomFileName(_storeLocation, fileInfo.Extension);

            fileInfo.CopyTo(thumbFileName);

            var thumbFileInfo = new FileInfo(thumbFileName);

            if(!thumbFileInfo.Exists)
                throw new FileNotFoundException("Unable to locate file copy to resize", thumbFileName);

            ImageUtil.ResizeImage(thumbFileName, ThumbWidthPixels);

            return thumbFileInfo.FullName;
        }

        public string SaveImageFile(string fileName, Stream inputStream)
        {
            var ext = Path.GetExtension(fileName);
            
            var fileInfo = new FileInfo(RandomFilenameHelper.GetRandomFileName(_storeLocation, ext));

            if (fileInfo.Exists)
                throw new ApplicationException("File already exits.");

            Debug.WriteLine("Saving file: " + fileInfo.FullName);

            var fileStream = new FileStream(fileInfo.FullName, FileMode.Create);
            int bytesRead = 0;
            var buffer = new byte[1024];

            try
            {
                do
                {
                    bytesRead = inputStream.Read(buffer, 0, 1024);
                    fileStream.Write(buffer, 0, bytesRead);

                } while (bytesRead > 0);
            }
            finally
            {
                fileStream.Close();
                fileStream.Dispose();
            }

            if(!new FileInfo(fileInfo.FullName).Exists)
                throw new FileNotFoundException("File not found.", fileInfo.FullName);

            ImageUtil.ResizeImage(fileInfo.FullName, FullWidthPixels);

            return fileInfo.FullName;
        }

    }
}