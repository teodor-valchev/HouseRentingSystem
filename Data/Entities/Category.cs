using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstants;

namespace HouseRentingSystem.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        //public List<House> Houses { get; set; } = new List<House>();
    }
}
