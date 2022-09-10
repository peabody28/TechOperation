using entities.Interfaces;
using System;

namespace entities
{
    public class RoleEntity : IRole
    {
        public Guid Id { get; set; }

        public string Code { get; set; }
    }
}
