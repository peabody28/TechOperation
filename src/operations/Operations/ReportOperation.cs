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

        public IReport Create(IUser user, string text, string photoPath, float? latitude, float? longitude)
        {
            return Container.InTransaction(() =>
            {
                ILocation location = null;
                if (latitude.HasValue && longitude.HasValue)
                    location = LocationRepository.Create(latitude.Value, longitude.Value);

                return ReportRepository.Create(user, location, text, photoPath);
            });
        }
    }
}
