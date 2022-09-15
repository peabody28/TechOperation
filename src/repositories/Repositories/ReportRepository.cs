using entities;
using entities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private Bank Bank { get; set; }

        public IServiceProvider Container { get; set; }

        public ReportRepository(Bank database, IServiceProvider container)
        {
            Bank = database;
            Container = container;
        }

        public IReport Create(IUser user, ILocation location)
        {
            var entity = Container.GetService<IReport>();
            entity.Id = Guid.NewGuid();
            entity.LocationId = location.Id;
            entity.UserId = user.Id;

            var report = Bank.Report.Add(entity as ReportEntity);
            Bank.SaveChanges();

            report.Entity.Location = location;
            report.Entity.User = user;

            return report.Entity;
        }
    }
}
