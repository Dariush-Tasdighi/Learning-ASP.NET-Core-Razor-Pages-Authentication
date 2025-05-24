using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Server.Pages.Security;

public class LoginModel : BasePageModel
{
	public LoginModel() : base()
	{
		ViewModel = new();
	}

	[Microsoft.AspNetCore.Mvc.BindProperty]
	public string? ReturnUrl { get; set; }

	[Microsoft.AspNetCore.Mvc.BindProperty]
	public ViewModels.Account.LoginViewModel ViewModel { get; set; }

	public void OnGet(string? returnUrl)
	{
		ReturnUrl = returnUrl;
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid == false)
		{
			return Page();
		}

		if (string.Compare(ViewModel.Username, "Dariush", ignoreCase: true) != 0 ||
			string.Compare(ViewModel.Password, "1234512345", ignoreCase: true) != 0)
		{
			AddPageError(message: "Wrong username and/or password!");

			return Page();
		}

		// Step (1)
		//await Infrastructure.Security
		//	.Utility.Login01(httpContext: HttpContext);

		// Step (8)
		//await Infrastructure.Security
		//	.Utility.Login02(httpContext: HttpContext);

		// Step (11)
		await Infrastructure.Security.Utility.Login03
			(httpContext: HttpContext, viewModel: ViewModel);

		if (string.IsNullOrWhiteSpace(value: ReturnUrl))
		{
			return RedirectToPage(pageName: "/Index");
		}
		else
		{
			return Redirect(url: ReturnUrl);
		}
	}
}
