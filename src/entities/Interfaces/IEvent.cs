namespace entities.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; set; }

        string Message { get; set; }

        IRole Role { get; set; }

        Guid RoleId { get; set; }

        bool IsConfirmed { get; set; }
    }
}
