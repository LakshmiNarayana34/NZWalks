using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="code has to be Minimum 3 characters")]
        [MaxLength(3,ErrorMessage ="code has to be Maximum 3 characters")]
        public string Code { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Name has to be minimum 3 characters")]
        [MaxLength(100,ErrorMessage ="Name has to be maximum 100 characters")]
        public string Name { get; set; }
        public string? RegionImgUrl { get; set; }
    }
}
