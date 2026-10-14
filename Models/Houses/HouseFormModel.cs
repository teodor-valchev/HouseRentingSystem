using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Models.Houses
{
    public class HouseFormModel
    {
        [Required]
        [StringLength(DataConstants.TitleMaxLength, MinimumLength = DataConstants.TitleMinLength)]
        public string Title { get; init; }

        [Required]
        [StringLength(
            DataConstants.AddressMaxLength,
            MinimumLength = DataConstants.AddressMinLength
        )]
        public string Address { get; init; }

        [Required]
        [StringLength(
            DataConstants.DescriptionMaxLength,
            MinimumLength = DataConstants.DescriptionMinLength
        )]
        public string Description { get; init; }

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [Range(00.00, 1000.00, ErrorMessage = "Price per month must be between {1} and {2}")]
        [Display(Name = "Price per Month")]
        public decimal PricePerMonth { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } =
            new List<HouseCategoryServiceModel>();
    }
}
