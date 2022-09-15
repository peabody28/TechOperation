using entities.Interfaces;

namespace repositories.Interfaces
{
    public interface IReportRepository
    {
        IReport Create(IUser user, ILocation location);
    }
}
