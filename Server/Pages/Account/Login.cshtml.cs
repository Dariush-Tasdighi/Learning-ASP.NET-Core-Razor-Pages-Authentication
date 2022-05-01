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

		public void OnPost()
		{
		}
	}
}
