using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Models
{
    public class EventFormViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(EventNameMaximumLength, 
            MinimumLength = EventNameMinimumLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(EventDescriptionMaximumLength,
            MinimumLength = EventDescriptionMinimumLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string End { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
