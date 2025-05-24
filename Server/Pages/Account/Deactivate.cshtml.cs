using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Account;

[Authorize]
public class DeactivateModel : Infrastructure.BasePageModel
{
	public DeactivateModel() : base()
	{
	}

	public void OnGet()
	{
	}
}
