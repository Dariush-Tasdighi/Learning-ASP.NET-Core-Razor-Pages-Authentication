using Microsoft.AspNetCore.Authentication;

namespace Server.Pages.Account
{
	public class LogoutModel : Infrastructure.BasePageModel
	{
		public LogoutModel() : base()
		{
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGet()
		{
			// SignOutAsync -> using Microsoft.AspNetCore.Authentication;
			await HttpContext.SignOutAsync(scheme: "Googooli");

			return RedirectToPage(pageName: "/Index");
		}
	}
}
