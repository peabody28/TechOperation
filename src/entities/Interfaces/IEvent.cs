namespace entities.Interfaces
{
    public interface IEvent
    {
        int Id { get; set; }

        string Title { get; set; }

        IRole Role { get; set; }

        bool IsConfirmed { get; set; }
    }
}
