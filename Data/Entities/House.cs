using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentingSystem.Data.Entities
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.NameMinLength)]
        [MaxLength(DataConstants.NameMaxLength)]
        public required string Title { get; set; }

        [Required]
        [MinLength(DataConstants.AddressMinLength)]
        [MaxLength(DataConstants.AddressMaxLength)]
        public required string Address { get; set; }

        [Required]
        [MinLength(DataConstants.DescriptionMinLength)]
        [MaxLength(DataConstants.DescriptionMaxLength)]
        public required string Description { get; set; }

        [Required]
        public required string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerMonth { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public string? RenterId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent? Agent { get; set; }

        public int AgentId { get; set; }
    }
}
