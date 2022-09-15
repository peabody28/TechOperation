using entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities
{
    [Table("report", Schema = "public")]
    public class ReportEntity : IReport
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string PhotoPath { get; set; }

        [ForeignKey("location")]
        public Guid LocationId { get; set; }

        public ILocation Location { get; set; }

        [ForeignKey("user")]
        public Guid UserId { get; set; }

        public IUser User { get; set; }

        ILocation IReport.Location 
        { 
            get => Location;
            set
            {
                Location = value as LocationEntity;
            }
        }

        IUser IReport.User
        {
            get => User;
            set
            {
                User = value as UserEntity;
            }
        }
    }
}
