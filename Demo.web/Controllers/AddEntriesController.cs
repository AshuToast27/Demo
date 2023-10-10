using Azure;
using Demo.web.Data;
using Demo.web.Models.Domain;
using Demo.web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo.web.Controllers
{
	public class AddEntriesController : Controller
	{
		private DemoDbContext demoDbContext;
		public AddEntriesController(DemoDbContext demoDbContext)
		{
			this.demoDbContext = demoDbContext;
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Add")]
		public IActionResult Add(AddEntryRequest addEntryRequest)
		{
			var user = new User
			{
				//mapping addTagRequest to tag domain model
				FirstName = addEntryRequest.Fname,
				LastName = addEntryRequest.Lname,
				DateOfBirth =addEntryRequest.Dob,
				City = addEntryRequest.City,
				Address = addEntryRequest.Address
			};
			demoDbContext.Users.Add(user);
			demoDbContext.SaveChanges();

			return View("Add");

		}
	}

}
