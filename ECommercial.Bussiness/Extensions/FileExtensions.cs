using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommercial.Bussiness.Extensions
{
    public static class FileExtensions
    {
        public static string GetFileExtension(this HttpPostedFileBase files)
        {
            string extension = new FileInfo(files.FileName).Extension;
            return extension;
        }
    }
}
