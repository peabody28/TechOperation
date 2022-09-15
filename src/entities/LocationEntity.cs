using entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities
{
    [Table("location", Schema = "public")]
    public class LocationEntity : ILocation
    {
        public Guid Id { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
