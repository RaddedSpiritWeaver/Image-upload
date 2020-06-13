using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ImageApi.Controllers
{
    [Route("Image")]
    public class ImageController : Controller
    {
        // POST: api/Image
        [HttpPost]
        public async Task Post(IFormFile file)
        {
            var uploads = Path.Combine("D:\\projects\\Net Core\\Image-Serve\\ImageApi\\StaticRoot", "uploads");
            if (file.Length > 0)
            {
                using var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
        }
    }
}