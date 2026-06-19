namespace ORM1.Models
{
    public class RoomImage_BCS240051
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = "";

        public bool IsThumbnail { get; set; }

        public int RoomId { get; set; }

        public Room_BCS240051? Room { get; set; }
    }
}
