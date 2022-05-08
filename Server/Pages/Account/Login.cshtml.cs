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
		public ViewModels.Account.LoginViewModel ViewModel { get; set; }

		//public void OnGet()
		//{
		//}

		//public async System.Threading.Tasks.Task
		//	<Microsoft.AspNetCore.Mvc.IActionResult> OnPost()
		//{
		//	if (ModelState.IsValid == false)
		//	{
		//		return Page();
		//	}

		//	if (string.Compare(ViewModel.Username, "Dariush", ignoreCase: true) != 0 ||
		//		string.Compare(ViewModel.Password, "1234512345", ignoreCase: true) != 0)
		//	{
		//		AddErrorMessage
		//			(message: "Wrong username and/or password!");

		//		return Page();
		//	}

		//	// Step (1)

		//	// **************************************************
		//	var claims =
		//		new System.Collections.Generic.List<System.Security.Claims.Claim>();

		//	System.Security.Claims.Claim claim;

		//	claim =
		//		new System.Security.Claims.Claim
		//		(type: System.Security.Claims.ClaimTypes.Name, value: "Dariush");

		//	claims.Add(item: claim);

		//	claim =
		//		new System.Security.Claims.Claim
		//		(type: System.Security.Claims.ClaimTypes.Email, value: "DariushT@GMail.com");

		//	claims.Add(item: claim);

		//	claim =
		//		new System.Security.Claims.Claim
		//		(type: "FullName", value: "Mr. Dariush Tasdighi");

		//	claims.Add(item: claim);
		//	// **************************************************

		//	var claimsIdentity =
		//		new System.Security.Claims.ClaimsIdentity
		//		(claims: claims, authenticationType: "Googooli");

		//	var claimsPrincipal =
		//		new System.Security.Claims.ClaimsPrincipal(identity: claimsIdentity);
		//	// **************************************************

		//	// **************************************************
		//	var now =
		//		System.DateTime.Now;

		//	var authenticationProperties =
		//		new Microsoft.AspNetCore.Authentication.AuthenticationProperties
		//		{
		//			AllowRefresh = true,
		//			IsPersistent = ViewModel.RememberMe,

		//			IssuedUtc = now,
		//			ExpiresUtc = now.AddMinutes(value: 20),

		//			//Items,
		//			//Parameters,
		//			//RedirectUri
		//		};
		//	// **************************************************

		//	// SignInAsync -> using Microsoft.AspNetCore.Authentication;
		//	await HttpContext.SignInAsync
		//		(scheme: "Googooli",
		//		principal: claimsPrincipal,
		//		properties: authenticationProperties);

		//	// Error!
		//	// We should activate Step (2)
		//	// An unhandled exception occurred while processing the request.

		//	return RedirectToPage(pageName: "/Index");
		//}

		/// <summary>
		/// Step (5)
		/// </summary>
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? ReturnUrl { get; set; }

		/// <summary>
		/// Step (5)
		/// </summary>
		public void OnGet(string returnUrl)
		{
			ReturnUrl = returnUrl;
		}

		/// <summary>
		/// Step (5)
		/// </summary>
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPost()
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			if (string.Compare(ViewModel.Username, "Dariush", ignoreCase: true) != 0 ||
				string.Compare(ViewModel.Password, "1234512345", ignoreCase: true) != 0)
			{
				AddToastError
					(message: "Wrong username and/or password!");

				return Page();
			}

			// Step (1)

			// **************************************************
			var claims =
				new System.Collections.Generic.List<System.Security.Claims.Claim>();

			System.Security.Claims.Claim claim;

			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Name, value: "Dariush");

			claims.Add(item: claim);

			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Email, value: "DariushT@GMail.com");

			claims.Add(item: claim);

			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Role, value: "Admin");

			claims.Add(item: claim);

			claim =
				new System.Security.Claims.Claim
				(type: "FullName", value: "Mr. Dariush Tasdighi");

			claims.Add(item: claim);
			// **************************************************

			var claimsIdentity =
				new System.Security.Claims.ClaimsIdentity
				(claims: claims, authenticationType: "Googooli");

			var claimsPrincipal =
				new System.Security.Claims.ClaimsPrincipal(identity: claimsIdentity);
			// **************************************************

			// **************************************************
			var now =
				System.DateTime.Now;

			var authenticationProperties =
				new Microsoft.AspNetCore.Authentication.AuthenticationProperties
				{
					AllowRefresh = true,
					IsPersistent = ViewModel.RememberMe,

					IssuedUtc = now,
					ExpiresUtc = now.AddMinutes(value: 20),

					//Items,
					//Parameters,
					//RedirectUri
				};
			// **************************************************

			// SignInAsync -> using Microsoft.AspNetCore.Authentication;
			await HttpContext.SignInAsync
				(scheme: "Googooli",
				principal: claimsPrincipal,
				properties: authenticationProperties);

			if (string.IsNullOrWhiteSpace(ReturnUrl))
			{
				return RedirectToPage(pageName: "/Index");
			}
			else
			{
				return Redirect(url: ReturnUrl);
			}
		}
	}
}
