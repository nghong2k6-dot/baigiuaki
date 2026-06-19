using System.Collections.Generic;

namespace ORM1.Models
{
    public class RoomSearchViewModel
    {
        public string? Keyword { get; set; }

        public int? RoomTypeId { get; set; }

        public bool? IsAvailable { get; set; }

        public decimal? MaxPrice { get; set; }

        public string? SortOrder { get; set; }

        public List<Room_BCS240051> Rooms { get; set; } = new();

        public List<RoomType_BCS240051> RoomTypes { get; set; } = new();
    }
}
