using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        void Delete(string filePath);
        string Update(IFormFile file, string filePath, string root);
        string Upload(IFormFile file, string imagesPath);
    }
}