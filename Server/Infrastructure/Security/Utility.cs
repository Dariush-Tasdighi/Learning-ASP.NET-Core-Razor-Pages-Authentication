using System;
using ViewModels.Account;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Infrastructure.Security;

public static class Utility : object
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
		CookieAuthenticationDefaults.AuthenticationScheme;

	public static List<Claim> GetClaims()
	{
		var claims = new List<Claim>();

		Claim claim;

		// **************************************************
		claim = new Claim(type: "FullName", value: "Mr. Dariush Tasdighi");
		claims.Add(item: claim);
		// **************************************************

		// **************************************************
		//claim = new Claim(type: "Name", value: "Dariush"); // کاملا غلط
		claim = new Claim(type: ClaimTypes.Name, value: "Dariush");
		claims.Add(item: claim);
		// **************************************************

		// **************************************************
		claim = new Claim(type: ClaimTypes.Email, value: "DariushT@GMail.com");
		claims.Add(item: claim);
		// **************************************************

		// **************************************************
		claim = new Claim(type: ClaimTypes.Role, value: "Admin");
		claims.Add(item: claim);
		// **************************************************

		// **************************************************
		// داشت Role اگر بیش از یک
		// **************************************************
		//claim = new Claim(type: ClaimTypes.Role, value: "Manager");
		//claims.Add(item: claim);
		// **************************************************

		return claims;
	}

	public static ClaimsIdentity GetClaimsIdentity()
	{
		var claims = GetClaims();

		var claimsIdentity = new ClaimsIdentity
			(claims: claims, authenticationType: AuthenticationScheme);

		return claimsIdentity;
	}

	public static ClaimsPrincipal GetClaimsPrincipal()
	{
		var claimsIdentity = GetClaimsIdentity();

		// **************************************************
		//var claimsPrincipal = new ClaimsPrincipal(identity: claimsIdentity);
		// **************************************************

		// **************************************************
		var claimsPrincipal = new ClaimsPrincipal();

		claimsPrincipal.AddIdentity(identity: claimsIdentity);
		// **************************************************

		return claimsPrincipal;
	}

	/// <summary>
	/// Step (1)
	/// </summary>
	public static async Task Login01(HttpContext httpContext)
	{
		var claimsPrincipal = GetClaimsPrincipal();

		await httpContext.SignInAsync(principal: claimsPrincipal);
	}

	/// <summary>
	/// Step (8)
	/// </summary>
	public static async Task Login02(HttpContext httpContext)
	{
		var claimsPrincipal = GetClaimsPrincipal();

		await httpContext.SignInAsync
			(scheme: AuthenticationScheme, principal: claimsPrincipal);
	}

	public static AuthenticationProperties GetAuthenticationProperties(LoginViewModel viewModel)
	{
		var now = DateTime.Now;

		var authenticationProperties = new AuthenticationProperties
		{
			//RedirectUri, // Default: null

			//Items, // Default: Count = 0
			//Parameters, // Default: Count = 0

			IssuedUtc = now, // Default:  // Default: null
			ExpiresUtc = now.AddSeconds(value: 10), // Default: null

			IsPersistent = viewModel.RememberMe, // Default: false
			AllowRefresh = true, // Default: null - Note: null is equal to true
		};

		return authenticationProperties;
	}

	/// <summary>
	/// Step (11)
	/// </summary>
	public static async Task Login03
		(HttpContext httpContext, LoginViewModel viewModel)
	{
		var claimsPrincipal = GetClaimsPrincipal();

		var authenticationProperties =
			GetAuthenticationProperties(viewModel: viewModel);

		await httpContext.SignInAsync(scheme: AuthenticationScheme,
			principal: claimsPrincipal, properties: authenticationProperties);
	}
}
