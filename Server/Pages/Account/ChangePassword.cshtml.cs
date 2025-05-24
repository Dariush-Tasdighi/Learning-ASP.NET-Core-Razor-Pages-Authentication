using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Account;

[Authorize]
public class ChangePasswordModel : Infrastructure.BasePageModel
{
	public ChangePasswordModel() : base()
	{
	}

	public void OnGet()
	{
	}
}
