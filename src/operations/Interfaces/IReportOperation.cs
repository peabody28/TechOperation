using entities.Interfaces;

namespace operations.Interfaces
{
    public interface IReportOperation
    {
        IReport CreateLocationReport(IUser user, float latitude, float longitude);
    }
}
