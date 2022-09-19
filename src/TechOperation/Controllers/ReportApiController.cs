using core;
using helpers;
using Microsoft.AspNetCore.Mvc;
using operations.Interfaces;
using repositories.Interfaces;
using TechOperation.Models.Report;

namespace TechOperation.Controllers
{
    public class ReportApiController : BaseApiController
    {
        #region [ Dependency -> Repositories ]

        public IUserRepository UserRepository { get; set; }

        #endregion

        #region [ Dependency -> Operations ]

        public IReportOperation ReportOperation { get; set; }

        #endregion

        public IConfiguration Configuration { get; set; }   

        public UploadFileHelper UploadFileHelper { get; set; }

        public ReportApiController(IUserRepository userRepository, IReportOperation reportOperation, IConfiguration configuration, UploadFileHelper uploadFileHelper)    
        {
            UserRepository = userRepository;
            ReportOperation = reportOperation;
            Configuration = configuration;
            UploadFileHelper = uploadFileHelper;
        }

        [HttpPost]
        public HttpResponseMessage Create([FromQuery] CreateReportModel model)
        {
            var user = UserRepository.Object(model.TelegramId);

            string path = null;
            if (Request.HasFormContentType && !HttpContext.Request.Form.Files.Count.Equals(0))
            {
                var folderPath = string.Format(Configuration.GetSection("Download:Image:Directory").Value, model.TelegramId.ToString());
                path = UploadFileHelper.Upload(HttpContext.Request.Form.Files.First(), folderPath);
            }

            var report = ReportOperation.Create(user, model.Text, path, model.Latitude, model.Longitude);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
