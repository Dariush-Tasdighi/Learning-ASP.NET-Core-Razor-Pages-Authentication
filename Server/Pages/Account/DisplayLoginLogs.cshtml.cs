using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Account;

[Authorize]
public class DisplayLoginLogsModel : Infrastructure.BasePageModel
{
	public DisplayLoginLogsModel() : base()
	{
	}

	public void OnGet()
	{
	}
}
