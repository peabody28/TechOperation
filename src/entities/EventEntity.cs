using entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities
{
    public class EventEntity : IEvent
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        [ForeignKey("Role")]
        public Guid RoleFk { get; set; }
        public IRole Role { get; set; }

        IRole IEvent.Role
        {
            get => Role;
            set
            {
                Role = value as RoleEntity;
            }
        }
    }
}
