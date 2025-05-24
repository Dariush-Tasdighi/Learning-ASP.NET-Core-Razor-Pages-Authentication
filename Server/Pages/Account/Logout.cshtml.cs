using Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Account;

[Authorize]
public class LogoutModel : BasePageModel
{
	public LogoutModel() : base()
	{
	}

	public async Task<IActionResult> OnGet()
	{
		await HttpContext.SignOutAsync
			(scheme: Infrastructure.Security.Utility.AuthenticationScheme);

		return RedirectToPage(pageName: "/Index");
	}
}
