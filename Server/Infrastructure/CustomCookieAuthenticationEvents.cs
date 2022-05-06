using Microsoft.AspNetCore.Authentication;

namespace Infrastructure
{
	public class CustomCookieAuthenticationEvents :
		Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
	{
		public CustomCookieAuthenticationEvents() : base()
		{
		}

		// Four callback points for login and logout are defined:

		public override System.Threading.Tasks.Task SigningIn
			(Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext context)
		{
			return base.SigningIn(context);
		}

		public override System.Threading.Tasks.Task SignedIn
			(Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext context)
		{
			return base.SignedIn(context);
		}
		public override System.Threading.Tasks.Task SigningOut
			(Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext context)
		{
			return base.SigningOut(context);
		}

		public override async System.Threading.Tasks.Task ValidatePrincipal
			(Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext context)
		{
			var userPrincipal = context.Principal;

			//// Look for the LastChanged claim.
			//var lastChanged =
			//	(from c in userPrincipal.Claims
			//	 where c.Type == "LastChanged"
			//	 select c.Value).FirstOrDefault();

			if (1 == 2)
			{
				context.RejectPrincipal();

				// SignOutAsync () -> using Microsoft.AspNetCore.Authentication;
				await context.HttpContext.SignOutAsync
					(Microsoft.AspNetCore.Authentication.Cookies
					.CookieAuthenticationDefaults.AuthenticationScheme);
			}
		}

		// Another 4 callback points for redirection

		public override System.Threading.Tasks.Task RedirectToLogin
			(Microsoft.AspNetCore.Authentication.RedirectContext
			<Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions> context)
		{
			return base.RedirectToLogin(context);
		}

		public override System.Threading.Tasks.Task RedirectToReturnUrl
			(Microsoft.AspNetCore.Authentication.RedirectContext
			<Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions> context)
		{
			return base.RedirectToReturnUrl(context);
		}

		public override System.Threading.Tasks.Task RedirectToAccessDenied
			(Microsoft.AspNetCore.Authentication.RedirectContext
			<Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions> context)
		{
			return base.RedirectToAccessDenied(context);
		}

		public override System.Threading.Tasks.Task RedirectToLogout
			(Microsoft.AspNetCore.Authentication.RedirectContext
			<Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationOptions> context)
		{
			return base.RedirectToLogout(context);
		}
	}
}
