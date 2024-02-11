using Homies.Data;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Controllers
{
	[Authorize]
	public class EventController : Controller
	{
		private readonly HomiesDbContext data;

		public EventController(HomiesDbContext context)
		{
			data = context;
		}

		public async Task<IActionResult> All()
		{
			var events = await data.Events
				.AsNoTracking()
				.Select(e => new EventInfoViewModel(
					e.Id,
					e.Name,
					e.Start,
					e.Type.Name,
					e.Organiser.UserName
					))
				.ToListAsync();

			return View(events);
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			var e = await data.Events
				.Where(e => e.Id == id)
				.Include(e => e.EventParticipants)
				.FirstOrDefaultAsync();

			if (e == null)
			{
				return BadRequest();
			}

			string userId = GetUserId();

			if (!e.EventParticipants.Any(p => p.HelperId == userId))
			{
                e.EventParticipants.Add(new EventParticipant()
                {
                    EventId = e.Id,
                    HelperId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

		[HttpGet]
		public async Task<IActionResult> Joined()
		{
			string userId = GetUserId();

			var model = await data.EventParticipants
				.Where(ep => ep.HelperId == userId)
				.AsNoTracking()
				.Select(ep => new EventInfoViewModel(
					ep.EventId,
					ep.Event.Name,
					ep.Event.Start,
					ep.Event.Type.Name,
					ep.Event.Organiser.UserName
					))
				.ToListAsync();

			return View(model);
		}

		public async Task<IActionResult> Leave(int id)
		{
            var e = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventParticipants)
                .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }

			string userId = GetUserId();

			var ep = e.EventParticipants.FirstOrDefault(ep => ep.HelperId == userId);


			if (ep == null)
			{
				return BadRequest();
            }

			e.EventParticipants.Remove(ep);

			await data.SaveChangesAsync();

			return View(nameof(All));
        }

		private string GetUserId()
		{
			return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}
	}
}
