namespace Server.Pages
{
	public class AboutModel : Infrastructure.BasePageModel
	{
		public AboutModel() : base()
		{
		}

		public Microsoft.AspNetCore.Mvc.IActionResult OnGet()
		{
			// **************************************************
			Messages.AddPageError(message: null);
			Messages.AddPageError(message: string.Empty);
			Messages.AddPageError(message: "               ");

			Messages.AddPageError(message: "     Page     Error     (1)     ");

			Messages.AddPageError(message: "Page Error (2)");
			Messages.AddPageError(message: "Page Error (3)");

			Messages.AddPageError(message: "Page Error (3)");
			// **************************************************

			// **************************************************
			Messages.AddPageWarning(message: null);
			Messages.AddPageWarning(message: string.Empty);
			Messages.AddPageWarning(message: "               ");

			Messages.AddPageWarning(message: "     Page     Warning     (1)     ");

			Messages.AddPageWarning(message: "Page Warning (2)");
			Messages.AddPageWarning(message: "Page Warning (3)");

			Messages.AddPageWarning(message: "Page Warning (3)");
			// **************************************************

			// **************************************************
			Messages.AddPageSuccess(message: null);
			Messages.AddPageSuccess(message: string.Empty);
			Messages.AddPageSuccess(message: "               ");

			Messages.AddPageSuccess(message: "     Page     Success     (1)     ");

			Messages.AddPageSuccess(message: "Page Success (2)");
			Messages.AddPageSuccess(message: "Page Success (3)");

			Messages.AddPageSuccess(message: "Page Success (3)");
			// **************************************************

			// **************************************************
			Messages.AddToastError(message: null);
			Messages.AddToastError(message: string.Empty);
			Messages.AddToastError(message: "               ");

			Messages.AddToastError(message: "     Toast     Error     (1)     ");

			Messages.AddToastError(message: "Toast Error (2)");
			Messages.AddToastError(message: "Toast Error (3)");

			Messages.AddToastError(message: "Toast Error (3)");
			// **************************************************

			// **************************************************
			Messages.AddToastWarning(message: null);
			Messages.AddToastWarning(message: string.Empty);
			Messages.AddToastWarning(message: "               ");

			Messages.AddToastWarning(message: "     Toast     Warning     (1)     ");

			Messages.AddToastWarning(message: "Toast Warning (2)");
			Messages.AddToastWarning(message: "Toast Warning (3)");

			Messages.AddToastWarning(message: "Toast Warning (3)");
			// **************************************************

			// **************************************************
			Messages.AddToastSuccess(message: null);
			Messages.AddToastSuccess(message: string.Empty);
			Messages.AddToastSuccess(message: "               ");

			Messages.AddToastSuccess(message: "     Toast     Success     (1)     ");

			Messages.AddToastSuccess(message: "Toast Success (2)");
			Messages.AddToastSuccess(message: "Toast Success (3)");

			Messages.AddToastSuccess(message: "Toast Success (3)");
			// **************************************************

			return RedirectToPage(pageName: "Contact");
		}
	}
}