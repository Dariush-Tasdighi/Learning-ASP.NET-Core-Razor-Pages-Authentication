using Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Account;

[Authorize]
public class AccessDeniedModel : BasePageModel
{
	public AccessDeniedModel() : base()
	{
	}

	public void OnGet()
	{
	}
}
