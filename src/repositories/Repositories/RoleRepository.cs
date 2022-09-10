using entities.Interfaces;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private Bank Bank { get; set; }

        public RoleRepository(Bank database)
        {
            Bank = database;
        }

        public IRole Object(string code)
        {
            return Bank.Role.FirstOrDefault(role => role.Code.Equals(code));
        }

        public IEnumerable<IRole> Collection()
        {
            return Bank.Role.Cast<IRole>();
        }
    }
}
