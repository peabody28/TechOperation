using core;
using Microsoft.AspNetCore.Mvc;
using repositories.Interfaces;
using TechOperation.Models.Role;

namespace TechOperation.Controllers
{
    public class RoleApiController : BaseApiController
    {
        #region [ Dependency -> Repositories ]

        private IRoleRepository RoleRepository { get; set; }

        #endregion

        public RoleApiController(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        [HttpGet]
        public IEnumerable<RoleModel> Roles()
        {
            var roles = RoleRepository.Collection();
            return roles.Select(role => new RoleModel { Code = role.Code });
        }
    }
}
