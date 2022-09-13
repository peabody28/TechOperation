using entities.Interfaces;

namespace entities
{
    public class EventEntity : IEvent
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IRole Role { get; set; }

        IRole IEvent.Role
        {
            get => Role;
            set
            {
                Role = value as RoleEntity;
            }
        }

        public bool IsConfirmed { get; set; }
    }
}
