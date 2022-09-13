namespace entities.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; set; }

        string Title { get; set; }

        Guid RoleFk { get; set; }

        IRole Role { get; set; }

        bool IsConfirmed { get; set; }
    }
}
