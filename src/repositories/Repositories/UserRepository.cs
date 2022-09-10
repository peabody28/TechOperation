using entities.Interfaces;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Bank Bank { get; set; }

        public UserRepository(Bank database)
        {
            Bank = database;
        }

        public IUser Object(string name)
        {
            var user = Bank.User.FirstOrDefault(user => user.Name.Equals(name));
            return user;
        }

        public IUser ObjectByPhone(string phoneNumber)
        {
            var user = Bank.User.FirstOrDefault(user => user.PhoneNumber.Equals(phoneNumber));
            return user;
        }

        public IEnumerable<IUser> Collection()
        {
            return Bank.User.Cast<IUser>();
        }
    }
}
