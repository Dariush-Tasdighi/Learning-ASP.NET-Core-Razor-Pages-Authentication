namespace Server.Pages.Admin
{
	[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Manager")]
	public class FileManagerModel : Infrastructure.BasePageModel
	{
		public FileManagerModel() : base()
		{
		}

		public void OnGet()
		{
		}
	}
}
