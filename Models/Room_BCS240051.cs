using System.ComponentModel.DataAnnotations;

namespace ORM1.Models
{
    public class Room_BCS240051
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public decimal Price { get; set; }

        public double Area { get; set; }

        public bool IsAvailable { get; set; }

        public string? Description { get; set; }

        public int RoomTypeId { get; set; }

        public RoomType_BCS240051? RoomType { get; set; }

        public ICollection<RoomImage_BCS240051>? RoomImages { get; set; }

        // Giá trên 1 mét vuông
        public decimal PricePerSquareMeter
        {
            get
            {
                if (Area == 0) return 0;
                return Price / (decimal)Area;
            }
        }
    }
}