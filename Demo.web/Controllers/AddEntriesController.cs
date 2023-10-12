using Azure;
using Demo.web.Data;
using Demo.web.Models.Domain;
using Demo.web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Demo.web.Controllers
{
	public class AddEntriesController : Controller
	{
		private readonly DemoDbContext demoDbContext;
		public AddEntriesController(DemoDbContext demoDbContext)
		{
			this.demoDbContext = demoDbContext;
		}

		[HttpGet]
		public IActionResult Show()
		{
			var entries = demoDbContext.Users.ToList();
			return View(entries);
		}





		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}


		[HttpPost]
		[ActionName("Add")]
		public IActionResult Add(User user)
		{
			var entry = new User
			{
				//mapping addTagRequest to tag domain model
				FirstName = user.FirstName,
				LastName = user.LastName,
				DateOfBirth = user.DateOfBirth,
				City = user.City,
				Address = user.Address
			};
			demoDbContext.Users.Add(entry);
			demoDbContext.SaveChanges();

			return View("Add");

		}

		[HttpPost]
		public IActionResult DeleteSelected(int[] selectedIds)
		{
			if (selectedIds != null && selectedIds.Length > 0)
			{
				foreach (int id in selectedIds)
				{
					var user = demoDbContext.Users.Find(id);
					if (user != null)
					{
						demoDbContext.Users.Remove(user);
					}
				}

				demoDbContext.SaveChanges();
			}

			return RedirectToAction("Show");
		}

	}
}
