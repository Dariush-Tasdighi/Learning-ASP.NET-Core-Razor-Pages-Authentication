using Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace Server.Pages.Admin;

[Authorize(Roles = "Admin, Manager")]
public class FileManagerModel : BasePageModel
{
	public FileManagerModel() : base()
	{
	}

	public void OnGet()
	{
	}
}
