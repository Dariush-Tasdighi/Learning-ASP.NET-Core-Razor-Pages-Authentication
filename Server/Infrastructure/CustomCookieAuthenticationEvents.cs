using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Infrastructure
{
	public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
	{
		// Four callback points for login and logout are defined:

		public override Task SigningIn(CookieSigningInContext context)
		{
			return base.SigningIn(context: context);
		}

		public override Task SignedIn(CookieSignedInContext context)
		{
			return base.SignedIn(context: context);
		}
		public override Task SigningOut(CookieSigningOutContext context)
		{
			return base.SigningOut(context: context);
		}

		public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
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
					(CookieAuthenticationDefaults.AuthenticationScheme);
			}
		}

		// Another 4 callback points for redirection

		public override Task RedirectToLogin
			(RedirectContext<CookieAuthenticationOptions> context)
		{
			return base.RedirectToLogin(context: context);
		}

		public override Task RedirectToReturnUrl
			(RedirectContext<CookieAuthenticationOptions> context)
		{
			return base.RedirectToReturnUrl(context: context);
		}

		public override Task RedirectToAccessDenied
			(RedirectContext<CookieAuthenticationOptions> context)
		{
			return base.RedirectToAccessDenied(context: context);
		}

		public override Task RedirectToLogout
			(RedirectContext<CookieAuthenticationOptions> context)
		{
			return base.RedirectToLogout(context: context);
		}
	}
}
