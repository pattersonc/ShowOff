using System;
using System.IO;

namespace ShowOff.Core.Util
{

    public static class RandomFilenameHelper
    {
        public static string GetRandomFileName(string path, string ext)
        {
            var fileName = Guid.NewGuid().ToString() + ext;
            return Path.Combine(path, fileName);
        }
    }

}