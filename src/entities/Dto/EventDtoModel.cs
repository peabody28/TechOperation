using System.ComponentModel.DataAnnotations.Schema;

namespace entities.Dto
{
    [Table("event", Schema = "public")]
    public class EventDtoModel
    {
        [Column("event_id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("role_code")]
        public string RoleCode { get; set; }

        [Column("is_confirmed")]
        public bool IsConfirmed { get; set; }
    }
}
