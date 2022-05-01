using Microsoft.AspNetCore.Authentication;

namespace Server.Pages.Security
{
	public class LoginModel : Infrastructure.BasePageModel
	{
		public LoginModel() : base()
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Security.LoginViewModel ViewModel { get; set; }

		public void OnGet()
		{
		}

		public Microsoft.AspNetCore.Mvc.IActionResult OnPost()
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			if (string.Compare(ViewModel.Username, "Dariush", ignoreCase: true) != 0 ||
				string.Compare(ViewModel.Password, "1234512345", ignoreCase: true) != 0)
			{
				AddErrorMessage
					(message: "Wrong username and/or password!");

				return Page();
			}


			// Step (1)

			var claims =
				new System.Collections.Generic.List<System.Security.Claims.Claim>();

			System.Security.Claims.Claim claim;

			claim =
				new System.Security.Claims.Claim(type: "", value: "");

			claims.Add(item: claim);

			var claimsIdentity =
				new System.Security.Claims.ClaimsIdentity
				(claims: claims, authenticationType: "Googooli");

			var claimsPrincipal =
				new System.Security.Claims.ClaimsPrincipal(identity: claimsIdentity);

			var now = System.DateTime.Now;

			var authenticationProperties =
				new Microsoft.AspNetCore.Authentication.AuthenticationProperties
				{
					//AllowRefresh = true,
					//IsPersistent = true,

					IssuedUtc = now,
					ExpiresUtc = now.AddMinutes(value: 20),

					//Items,
					//Parameters,
					//RedirectUri
				};

			// SignInAsync -> using Microsoft.AspNetCore.Authentication;
			HttpContext.SignInAsync
				(scheme: "Googooli",
				principal: claimsPrincipal,
				properties: authenticationProperties);

			return RedirectToPage(pageName: "/Index");
		}
	}
}
