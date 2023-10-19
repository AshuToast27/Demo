using Azure;
using Demo.web.Data;
using Demo.web.Models.Domain;
using Demo.web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo.web.Controllers
{
	public class AddEntriesController : Controller
	{
		private readonly DemoDbContext demoDbContext;
		private IWebHostEnvironment hostenv;
		public AddEntriesController(DemoDbContext demoDbContext, IWebHostEnvironment env)
		{
			this.demoDbContext = demoDbContext;
			hostenv = env;
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
		public IActionResult Add(AddEntryRequest addEntry)
		{
			try
			{
				if (ModelState.IsValid)
				{
					string Filename = "";
					if(addEntry.Photo != null) 
					{
						string uploadFolder = Path.Combine(hostenv.WebRootPath, "images");
						Filename = Guid.NewGuid().ToString() + "_" + addEntry.Photo.FileName;
						string Filepath= Path.Combine(uploadFolder, Filename);
						addEntry.Photo.CopyTo(new FileStream(Filepath, FileMode.Create));

					}

					var entry = new User()
					{
						//mapping addTagRequest to tag domain model
						FirstName = addEntry.Fname,
						LastName = addEntry.Lname,
						DateOfBirth = addEntry.Dob,
						City = addEntry.City,
						Address = addEntry.Address,
						Mail = addEntry.Mail,
						Photo = Filename
					};
					demoDbContext.Users.Add(entry);
					demoDbContext.SaveChanges();
					TempData["successMessage"] = "Entry Added!";
					return RedirectToAction("Add");
				}
				else
				{
					TempData["errorMessage"] = "Entry Added!";
					return RedirectToAction("Show");
				}
			}
			catch (Exception e)
			{

				TempData["errorMessage"] = e.Message;
				return RedirectToAction("Index");
			}


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
