using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MVCIntroDemo.Controllers
{
	public class ProductController : Controller
	{
		private readonly IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 15
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Ham",
				Price = 5
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Bread",
				Price = 2
			},
		};
		public IActionResult Index()
		{
			return View(products);
		}

		public IActionResult ById(int id)
		{
			if (id < 1 || id > products.Count())
			{
				TempData["Error"] = "No such product";

				return RedirectToAction(nameof(Index));
			}

			return View(products.FirstOrDefault(p => p.Id == id));
		}

		public IActionResult AllAsJSON()
		{
			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				WriteIndented = true,
			};

			return Json(products, options);
		}

		public IActionResult AllAsPlainText()
		{
			return Content(GetAllProductsAsString());
		}

		public IActionResult DownloadAll()
		{
			string content = GetAllProductsAsString();
			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

			return File(Encoding.UTF8.GetBytes(content), "text/plain");
		}

		public IActionResult Filtered(string? keyword = null)
		{
			if(keyword == null)
			{
				return RedirectToAction(nameof(Index));
			}

			var model = products
				.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

			return View(nameof(Index), model);
		}
		private string GetAllProductsAsString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var items in products)
			{
				sb.AppendLine($"Procut {items.Id}: {items.Name} - {items.Price} lv.");
			}

			return sb.ToString();
		}
	}
}
