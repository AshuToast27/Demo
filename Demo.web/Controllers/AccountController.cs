using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Demo.web.Models.Domain;
using Demo.web.Models.ViewModels;

namespace Demo.web.Controllers
{
	
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountController(UserManager< ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> Register(AddEntryRequest model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Mail, Email = model.Mail };
				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					// Generate email confirmation token
					var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

					// Send email confirmation link to the user
					var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

					// Send the confirmation link to the user's email address (implement your email sending logic here)
					// Example: await _emailSender.SendEmailAsync(model.Email, "Confirm your email", $"Please confirm your email by clicking this link: {confirmationLink}");

					// Redirect to a page indicating that email verification is required
					return RedirectToAction("RegistrationConfirmation");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		}
	}
}
