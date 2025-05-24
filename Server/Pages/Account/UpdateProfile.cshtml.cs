using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Account
{
	// Step (3)
	// Note: [Authorize] Attribute Does not work!
	// We should activate Step (4)
	[Authorize]
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
