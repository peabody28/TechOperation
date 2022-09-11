using entities.Interfaces;
using TechOperation.Models.User;

namespace TechOperation.ModelBuilder
{
    public class UserModelBuilder
    {
        public static UserModel Build(IUser user)
        {
            if (user == null)
                return null;

            return new UserModel
            {
                Name = user.Name,
                RoleCode = user.Role.Code,
                TelegramId = user.TelegramId.Value,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
