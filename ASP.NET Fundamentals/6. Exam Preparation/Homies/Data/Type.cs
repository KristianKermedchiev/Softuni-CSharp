using System.ComponentModel.DataAnnotations;

namespace Homies.Data
{
	public class Type
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(DataConstants.TypeNameMaximumLength)]
		public string Name { get; set; }

		public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
