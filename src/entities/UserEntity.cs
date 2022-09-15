using entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities
{
    [Table("user", Schema = "public")]
    public class UserEntity : IUser
    {
        public Guid Id { get; set; }

        public int? TelegramId { get; set; }

        public string Name { get; set; }

        [ForeignKey("role")]
        public Guid RoleId { get; set; }

        public IRole Role { get; set; }

        public string PhoneNumber { get; set; }

        IRole IUser.Role
        {
            get => Role;
            set
            {
                Role = value as RoleEntity;
            }
        }
    }
}