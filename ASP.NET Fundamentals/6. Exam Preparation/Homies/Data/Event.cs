﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Data.DataConstants;
namespace Homies.Data
{
	public class Event
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(EventNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

		[Required]
		[MaxLength(EventDescriptionMaximumLength)]
		public string Description { get; set; } = string.Empty;

		[Required]
		public string OrganiserId { get; set; } = string.Empty;

		[Required]
		[ForeignKey(nameof(OrganiserId))]
		public IdentityUser Organiser { get; set; } = null;

		[Required]
		public DateTime CreatedOn { get; set; }

		[Required]
		public DateTime Start { get; set; }

		[Required]
		public DateTime End { get; set; }

		[Required]
		public int TypeId { get; set; }

		[ForeignKey(nameof(TypeId))]
		[Required]
		public Type Type { get; set; } = null!;

		public IList<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
	}
}
