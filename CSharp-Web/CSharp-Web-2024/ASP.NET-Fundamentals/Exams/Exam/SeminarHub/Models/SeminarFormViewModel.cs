using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Models
{
    public class SeminarFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarTopicMaximumLength,
            MinimumLength = SeminarTopicMinimumLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarLecturerMaximumLength,
            MinimumLength = SeminarLecturerMinimumLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarDetailsMaximumLength,
            MinimumLength = SeminarDetailsMinimumLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string DateAndTime { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string Duration { get; set; } = string.Empty;


        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
