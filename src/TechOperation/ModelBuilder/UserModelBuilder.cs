using entities.Interfaces;
using TechOperations.Models.User;

namespace TechOperations.ModelBuilder
{
    public class UserModelBuilder
    {
        public static UserModel Build(IUser user)
        {
            if (user == null)
                return null;
            return new UserModel { Name = user.Name, RoleCode = user.Role.Code };
        }
    }
}
