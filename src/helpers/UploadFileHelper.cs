using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace helpers
{
    public class UploadFileHelper
    {
        public IConfiguration Configuration { get; set; }

        public UploadFileHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Save file to the folder path and return a filePath
        /// </summary>
        /// <returns>Path to the file</returns>
        public string Upload(IFormFile file, string folderPath)
        {
            Directory.CreateDirectory(folderPath);

            var fileName = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMdd-HHmmss"), ".jpg");

            string filePath = string.Concat(folderPath, fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(fileStream).Wait();
            }
            return filePath;
        }
    }
}