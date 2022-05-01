namespace Server.Pages.Account
{
	// Step (3)
	// Note: [Authorize] Attribute Does not work!
	// We should activate Step (4)
	[Microsoft.AspNetCore.Authorization.Authorize]
	public class UpdateProfileModel : Infrastructure.BasePageModel
	{
		public UpdateProfileModel() : base()
		{
		}

		public void OnGet()
		{
		}
	}
}
