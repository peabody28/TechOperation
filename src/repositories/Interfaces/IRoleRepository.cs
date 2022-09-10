using entities.Interfaces;
using System.Collections.Generic;

namespace repositories.Interfaces
{
    public interface IRoleRepository
    {
        IRole Object(string code);

        IEnumerable<IRole> Collection();
    }
}
