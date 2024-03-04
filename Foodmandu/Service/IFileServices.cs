using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foodmandu.Service
{
    public interface IFileServices
    {
        string Save(string dirPath, IFormFile file);
        string CheckOrCreateDirectory(string path);
    }
}
