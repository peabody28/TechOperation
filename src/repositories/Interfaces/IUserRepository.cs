using entities.Interfaces;

namespace repositories.Interfaces
{
    public interface IUserRepository
    {
        IUser Create(IRole role, int telegramId, string name, string phoneNumber);

        IUser Object(string name);

        IUser Object(int telegramId);

        IUser ObjectByPhone(string phoneNumber);

        IEnumerable<IUser> Collection(string roleCode = null);
    }
}
