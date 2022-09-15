namespace entities.Interfaces
{
    public interface ILocation
    {
        Guid Id { get; set; }

        float Latitude { get; set; }

        float Longitude { get; set; }
    }
}
