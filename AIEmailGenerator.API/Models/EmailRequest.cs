using System.ComponentModel.DataAnnotations;

namespace AIEmailGenerator.API.Models
{
    public class EmailRequest
    {
        [Required(ErrorMessage = "Purpose is required.")]
        [StringLength(100)]
        public string Purpose { get; set; } = string.Empty;

        [Required(ErrorMessage = "Recipient is required.")]
        [StringLength(100)]
        public string Recipient { get; set; } = string.Empty;

        [Required(ErrorMessage = "Key points are required.")]
        [StringLength(1000)]
        public string KeyPoints { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tone is required.")]
        [RegularExpression("^(Professional|Friendly|Formal|Casual)$",
            ErrorMessage = "Tone must be Professional, Friendly, Formal or Casual.")]
        public string Tone { get; set; } = string.Empty;
    }
}
