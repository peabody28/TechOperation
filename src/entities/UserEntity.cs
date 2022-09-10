using entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities
{
    public class UserEntity : IUser
    {
        public Guid Id { get; set; }

        public int TelegramId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Role")]
        public Guid RoleFk { get; set; }
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