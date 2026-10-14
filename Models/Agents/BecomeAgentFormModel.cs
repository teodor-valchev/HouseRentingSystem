using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Data;

namespace HouseRentingSystem.Models.Agents
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(
            DataConstants.PhoneNumberMaxLength,
            MinimumLength = DataConstants.PhoneNumberMinLength
        )]
        [Phone]
        public string PhoneNumber { get; init; }
    }
}
