using entities.Interfaces;
using operations.Interfaces;
using repositories.Extensions;
using repositories.Interfaces;

namespace operations.Operations
{
    public class ReportOperation : IReportOperation
    {
        #region [ Dependency -> Repositories ]

        public ILocationRepository LocationRepository { get; set; }

        public IReportRepository ReportRepository { get; set; }

        #endregion

        public IServiceProvider Container { get; set; }

        public ReportOperation(ILocationRepository locationRepository, IReportRepository reportRepository, IServiceProvider container)
        {
            LocationRepository = locationRepository;
            ReportRepository = reportRepository;
            Container = container;
        }

        public IReport CreateLocationReport(IUser user, float latitude, float longitude)
        {
            return Container.InTransaction(() => 
            {
                var location = LocationRepository.Create(latitude, longitude);
                return ReportRepository.Create(user, location);
            });
        }
    }
}
