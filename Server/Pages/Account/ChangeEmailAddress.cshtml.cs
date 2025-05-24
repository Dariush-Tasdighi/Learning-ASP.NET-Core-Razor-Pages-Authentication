using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Account;

[Authorize]
public class ChangeEmailAddressModel : Infrastructure.BasePageModel
{
	public ChangeEmailAddressModel() : base()
	{
	}

	public void OnGet()
	{
	}
}
