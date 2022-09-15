using entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities
{
    [Table("role", Schema = "public")]
    public class RoleEntity : IRole
    {
        public Guid Id { get; set; }

        public string Code { get; set; }
    }
}
