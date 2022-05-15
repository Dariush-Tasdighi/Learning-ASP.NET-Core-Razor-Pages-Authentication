using Microsoft.AspNetCore.Authentication;

namespace Infrastructure.Security
{
	public static class Utility
	{
		/// <summary>
		/// Step (1)
		/// </summary>
		//public const string AuthenticationScheme = "Magooli";

		/// <summary>
		/// Step (9)
		/// </summary>
		//public const string AuthenticationScheme = "Googooli";

		/// <summary>
		/// Step (10)
		/// </summary>
		public const string AuthenticationScheme =
			Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;

		static Utility()
		{
		}

		public static System.Collections.Generic
			.List<System.Security.Claims.Claim> GetClaims()
		{
			var claims =
				new System.Collections.Generic
				.List<System.Security.Claims.Claim>();

			System.Security.Claims.Claim claim;

			// **************************************************
			claim =
				new System.Security.Claims.Claim
				(type: "FullName", value: "Mr. Dariush Tasdighi");

			claims.Add(item: claim);
			// **************************************************

			// **************************************************
			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Name, value: "Dariush");

			claims.Add(item: claim);
			// **************************************************

			// **************************************************
			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Email, value: "DariushT@GMail.com");

			claims.Add(item: claim);
			// **************************************************

			// **************************************************
			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Role, value: "Admin");

			claims.Add(item: claim);
			// **************************************************

			return claims;
		}

		public static System.Security.Claims.ClaimsIdentity GetClaimsIdentity()
		{
			var claims =
				GetClaims();

			var claimsIdentity =
				new System.Security.Claims.ClaimsIdentity
				(claims: claims, authenticationType: AuthenticationScheme);

			return claimsIdentity;
		}

		public static System.Security.Claims
			.ClaimsPrincipal GetClaimsPrincipal()
		{
			var claimsIdentity =
				GetClaimsIdentity();

			// **************************************************
			//var claimsPrincipal =
			//	new System.Security.Claims.ClaimsPrincipal(identity: claimsIdentity);
			// **************************************************

			// **************************************************
			var claimsPrincipal =
				new System.Security.Claims.ClaimsPrincipal();

			claimsPrincipal.AddIdentity(identity: claimsIdentity);
			// **************************************************

			return claimsPrincipal;
		}

		/// <summary>
		/// Step (1)
		/// </summary>
		public static async System.Threading.Tasks.Task
			Login01(Microsoft.AspNetCore.Http.HttpContext httpContext)
		{
			var claimsPrincipal =
				GetClaimsPrincipal();

			// SignInAsync -> using Microsoft.AspNetCore.Authentication;
			await httpContext.SignInAsync
				(principal: claimsPrincipal);
		}

		/// <summary>
		/// Step (8)
		/// </summary>
		public static async System.Threading.Tasks.Task
			Login02(Microsoft.AspNetCore.Http.HttpContext httpContext)
		{
			var claimsPrincipal =
				GetClaimsPrincipal();

			// SignInAsync -> using Microsoft.AspNetCore.Authentication;
			await httpContext.SignInAsync
				(scheme: AuthenticationScheme, principal: claimsPrincipal);
		}

		public static Microsoft.AspNetCore.Authentication.AuthenticationProperties
			GetAuthenticationProperties(ViewModels.Account.LoginViewModel viewModel)
		{
			var now =
				System.DateTime.Now;

			var temp =
				new Microsoft.AspNetCore.Authentication.AuthenticationProperties();

			var result =
				new Microsoft.AspNetCore.Authentication.AuthenticationProperties
				{
					//RedirectUri, // Default: null

					//Items, // Default: Count = 0
					//Parameters, // Default: Count = 0

					IssuedUtc = now, // Default:  // Default: null
					ExpiresUtc = now.AddSeconds(value: 10), // Default: null

					IsPersistent = viewModel.RememberMe, // Default: false
					AllowRefresh = true, // Default: null - Note: null is equal to true
				};

			return result;
		}

		/// <summary>
		/// Step (11)
		/// </summary>
		public static async System.Threading.Tasks.Task Login03
			(Microsoft.AspNetCore.Http.HttpContext httpContext,
			ViewModels.Account.LoginViewModel viewModel)
		{
			var claimsPrincipal =
				GetClaimsPrincipal();

			var authenticationProperties =
				GetAuthenticationProperties(viewModel: viewModel);

			// SignInAsync -> using Microsoft.AspNetCore.Authentication;
			await httpContext.SignInAsync
				(scheme: AuthenticationScheme,
				principal: claimsPrincipal, properties: authenticationProperties);
		}
	}
}
