namespace Infrastructure
{
	public abstract class BasePageModel :
		Microsoft.AspNetCore.Mvc.RazorPages.PageModel
	{
		public BasePageModel() : base()
		{
		}

		public Messages Messages
		{
			get
			{
				var messages =
					TempData[key: Messages.KeyName] as Messages;

				if (messages == null)
				{
					messages = new();

					TempData[key: Messages.KeyName] = messages;
				}

				return messages;
			}
		}
	}
}
