using entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities
{
    [Table("event", Schema = "public")]
    public class EventEntity : IEvent
    {
        public Guid Id { get; set; }
        
        public string Message { get; set; }

        [ForeignKey("role")]
        public Guid RoleId { get; set; }
        public IRole Role { get; set; }

        public bool IsConfirmed { get; set; }

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
