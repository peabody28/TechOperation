namespace entities.Interfaces
{
    public interface IReport
    {
        Guid Id { get; set; }

        string Text { get; set; }

        string PhotoPath { get; set; }

        Guid LocationId { get; set; }

        ILocation Location { get; set; }

        Guid UserId { get; set; }

        IUser User { get; set; }
    }
}
