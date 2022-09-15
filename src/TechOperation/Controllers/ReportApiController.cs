using core;
using Microsoft.AspNetCore.Http;
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

        public ReportApiController(IUserRepository userRepository, IReportOperation reportOperation)
        {
            UserRepository = userRepository;
            ReportOperation = reportOperation;
        }

        [HttpPost]
        public HttpResponseMessage CreateLocationReport(CreateLocationReportModel model)
        {
            var user = UserRepository.Object(model.TelegramId);

            var report = ReportOperation.CreateLocationReport(user, model.Latitude, model.Longitude);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}
