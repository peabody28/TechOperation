using entities.Interfaces;
using System.Collections.Generic;

namespace repositories.Interfaces
{
    public interface IUserRepository
    {
        IUser Object(string name);

        IUser ObjectByPhone(string phoneNumber);

        IEnumerable<IUser> Collection();
    }
}
