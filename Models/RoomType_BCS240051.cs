using System.ComponentModel.DataAnnotations;

namespace ORM1.Models
{
    public class RoomType_BCS240051
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public string? Description { get; set; }

        public ICollection<Room_BCS240051>? Rooms { get; set; }
    }
}