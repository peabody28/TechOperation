using entities.Interfaces;

namespace operations.Interfaces
{
    public interface IReportOperation
    {
        IReport Create(IUser user, string text, string photoPath, float? latitude, float? longitude);
    }
}
