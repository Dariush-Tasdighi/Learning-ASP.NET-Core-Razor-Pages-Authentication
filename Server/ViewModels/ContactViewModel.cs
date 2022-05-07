namespace ViewModels
{
	public class ContactViewModel : object
	{
		public ContactViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "Full Name")]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 50,
			ErrorMessage = "The maximum length of {0} is {1}!")]
		public string? FullName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "Subject")]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 100,
			ErrorMessage = "The maximum length of {0} is {1}!")]
		public string? Subject { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "Body")]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 1000,
			ErrorMessage = "The maximum length of {0} is {1}!")]

		[System.ComponentModel.DataAnnotations.DataType
			(dataType: System.ComponentModel.DataAnnotations.DataType.MultilineText)]
		public string? Body { get; set; }
		// **********
	}
}
