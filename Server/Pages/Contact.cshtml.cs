namespace Server.Pages
{
	public class ContactModel : Infrastructure.BasePageModel
	{
		public ContactModel() : base()
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.ContactViewModel ViewModel { get; set; }

		public void OnGet()
		{
			// **************************************************
			Messages.AddPageError(message: null);
			Messages.AddPageError(message: string.Empty);
			Messages.AddPageError(message: "               ");

			Messages.AddPageError(message: "     Page     Error     (4)     ");

			Messages.AddPageError(message: "Page Error (5)");
			Messages.AddPageError(message: "Page Error (6)");

			Messages.AddPageError(message: "Page Error (6)");
			// **************************************************

			// **************************************************
			Messages.AddPageWarning(message: null);
			Messages.AddPageWarning(message: string.Empty);
			Messages.AddPageWarning(message: "               ");

			Messages.AddPageWarning(message: "     Page     Warning     (4)     ");

			Messages.AddPageWarning(message: "Page Warning (5)");
			Messages.AddPageWarning(message: "Page Warning (6)");

			Messages.AddPageWarning(message: "Page Warning (6)");
			// **************************************************

			// **************************************************
			Messages.AddPageSuccess(message: null);
			Messages.AddPageSuccess(message: string.Empty);
			Messages.AddPageSuccess(message: "               ");

			Messages.AddPageSuccess(message: "     Page     Success     (4)     ");

			Messages.AddPageSuccess(message: "Page Success (5)");
			Messages.AddPageSuccess(message: "Page Success (6)");

			Messages.AddPageSuccess(message: "Page Success (6)");
			// **************************************************

			// **************************************************
			Messages.AddToastError(message: null);
			Messages.AddToastError(message: string.Empty);
			Messages.AddToastError(message: "               ");

			Messages.AddToastError(message: "     Toast     Error     (4)     ");

			Messages.AddToastError(message: "Toast Error (5)");
			Messages.AddToastError(message: "Toast Error (6)");

			Messages.AddToastError(message: "Toast Error (6)");
			// **************************************************

			// **************************************************
			Messages.AddToastWarning(message: null);
			Messages.AddToastWarning(message: string.Empty);
			Messages.AddToastWarning(message: "               ");

			Messages.AddToastWarning(message: "     Toast     Warning     (4)     ");

			Messages.AddToastWarning(message: "Toast Warning (5)");
			Messages.AddToastWarning(message: "Toast Warning (6)");

			Messages.AddToastWarning(message: "Toast Warning (6)");
			// **************************************************

			// **************************************************
			Messages.AddToastSuccess(message: null);
			Messages.AddToastSuccess(message: string.Empty);
			Messages.AddToastSuccess(message: "               ");

			Messages.AddToastSuccess(message: "     Toast     Success     (4)     ");

			Messages.AddToastSuccess(message: "Toast Success (5)");
			Messages.AddToastSuccess(message: "Toast Success (6)");

			Messages.AddToastSuccess(message: "Toast Success (6)");
			// **************************************************
		}
	}
}
