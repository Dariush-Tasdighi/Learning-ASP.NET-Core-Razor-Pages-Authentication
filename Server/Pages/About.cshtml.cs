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
			AddPageError(message: null);
			AddPageError(message: string.Empty);
			AddPageError(message: "               ");

			AddPageError(message: "     Page     Error     (1)     ");

			AddPageError(message: "Page Error (2)");
			AddPageError(message: "Page Error (3)");

			AddPageError(message: "Page Error (3)");
			// **************************************************

			// **************************************************
			AddPageWarning(message: null);
			AddPageWarning(message: string.Empty);
			AddPageWarning(message: "               ");

			AddPageWarning(message: "     Page     Warning     (1)     ");

			AddPageWarning(message: "Page Warning (2)");
			AddPageWarning(message: "Page Warning (3)");

			AddPageWarning(message: "Page Warning (3)");
			// **************************************************

			// **************************************************
			AddPageSuccess(message: null);
			AddPageSuccess(message: string.Empty);
			AddPageSuccess(message: "               ");

			AddPageSuccess(message: "     Page     Success     (1)     ");

			AddPageSuccess(message: "Page Success (2)");
			AddPageSuccess(message: "Page Success (3)");

			AddPageSuccess(message: "Page Success (3)");
			// **************************************************

			// **************************************************
			AddToastError(message: null);
			AddToastError(message: string.Empty);
			AddToastError(message: "               ");

			AddToastError(message: "     Toast     Error     (1)     ");

			AddToastError(message: "Toast Error (2)");
			AddToastError(message: "Toast Error (3)");

			AddToastError(message: "Toast Error (3)");
			// **************************************************

			// **************************************************
			AddToastWarning(message: null);
			AddToastWarning(message: string.Empty);
			AddToastWarning(message: "               ");

			AddToastWarning(message: "     Toast     Warning     (1)     ");

			AddToastWarning(message: "Toast Warning (2)");
			AddToastWarning(message: "Toast Warning (3)");

			AddToastWarning(message: "Toast Warning (3)");
			// **************************************************

			// **************************************************
			AddToastSuccess(message: null);
			AddToastSuccess(message: string.Empty);
			AddToastSuccess(message: "               ");

			AddToastSuccess(message: "     Toast     Success     (1)     ");

			AddToastSuccess(message: "Toast Success (2)");
			AddToastSuccess(message: "Toast Success (3)");

			AddToastSuccess(message: "Toast Success (3)");
			// **************************************************

			return RedirectToPage(pageName: "Contact");
		}
	}
}
