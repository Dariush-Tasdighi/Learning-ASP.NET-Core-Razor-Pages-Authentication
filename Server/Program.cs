// **************************************************
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
// **************************************************

// **************************************************
var webApplicationOptions =
	new Microsoft.AspNetCore.Builder.WebApplicationOptions
	{
		EnvironmentName =
			System.Diagnostics.Debugger.IsAttached ?
			Microsoft.Extensions.Hosting.Environments.Development
			:
			Microsoft.Extensions.Hosting.Environments.Production,
	};

var builder =
	Microsoft.AspNetCore.Builder
	.WebApplication.CreateBuilder(options: webApplicationOptions);
// **************************************************

// **************************************************
// Step (2)
// **************************************************
// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-6.0
// https://www.red-gate.com/simple-talk/development/dotnet-development/using-auth-cookies-in-asp-net-core/
// https://programmer.ink/think/understand-asp-net-core-cookie-authentication.html
// https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authentication/cookie.mdhttps://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authentication/cookie.md

// https://driesdeboosere.dev/blog/how-to-add-cookie-consent-in-aspnet-core-50/https://driesdeboosere.dev/blog/how-to-add-cookie-consent-in-aspnet-core-50/
// **************************************************
// Replace 'Googooli' to:
//Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
// **************************************************
builder.Services.AddScoped
	<Infrastructure.CustomCookieAuthenticationEvents>();

builder.Services
	.AddAuthentication(defaultScheme: "Googooli")
	.AddCookie(authenticationScheme: "Googooli", options =>
	{
		options.LoginPath = "/Account/Login";
		options.ReturnUrlParameter = "ReturnUrl";

		options.LogoutPath = "/Account/Logout";
		options.AccessDeniedPath = "/Account/AccessDenied";

		options.ClaimsIssuer = "DTAT";

		//options.Cookie.Domain;
		//options.Cookie.MaxAge;
		//options.Cookie.Expiration;
		options.Cookie.Path = "/";
		options.Cookie.Name = "Googooli";
		options.Cookie.HttpOnly = true; // Default: 'true'
		options.Cookie.IsEssential = true; // Default: 'true'
		options.Cookie.SameSite =
			Microsoft.AspNetCore.Http.SameSiteMode.Lax; // Default: 'Lax'
		options.Cookie.SecurePolicy =
			Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;

		options.ExpireTimeSpan =
			System.TimeSpan.FromMinutes(value: 1); // Default: 14 Days

		options.SlidingExpiration = true; // Default: 'true'

		//options.ForwardSignIn
		//options.ForwardForbid
		//options.ForwardDefault
		//options.ForwardSignOut
		//options.ForwardChallenge
		//options.ForwardAuthenticate
		//options.ForwardDefaultSelector

		//options.SessionStore
		//options.CookieManager
		//options.TicketDataFormat
		//options.DataProtectionProvider

		options.EventsType =
			typeof(Infrastructure.CustomCookieAuthenticationEvents);

		//options.Events.OnCheckSlidingExpiration = (context) =>
		//{
		//	return System.Threading.Tasks.Task.CompletedTask;
		//};

		options.Validate();
	});

// Note: Does not work!
// We should activate Step (3)
// **************************************************

// **************************************************
builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;

	//options.AppendTrailingSlash
	//options.SuppressCheckForUnhandledSecurityMetadata = false;
});
// **************************************************

// **************************************************
// AddHttpContextAccessor() -> using Microsoft.Extensions.DependencyInjection;
builder.Services.AddHttpContextAccessor();
// **************************************************

// **************************************************
// AddRazorPages() -> using Microsoft.Extensions.DependencyInjection;
builder.Services.AddRazorPages();
// **************************************************

// **************************************************
var app =
	builder.Build();
// **************************************************

// **************************************************
// UseHttpsRedirection() -> using Microsoft.AspNetCore.Builder;
app.UseHttpsRedirection();
// **************************************************

// **************************************************
// UseStaticFiles() -> using Microsoft.AspNetCore.Builder;
app.UseStaticFiles();
// **************************************************

// **************************************************
//var cookiePolicyOptions =
//	new Microsoft.AspNetCore.Builder.CookiePolicyOptions
//	{
//		MinimumSameSitePolicy =
//			Microsoft.AspNetCore.Http.SameSiteMode.Strict,

//		HttpOnly =
//			Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,

//		OnAppendCookie = (context) =>
//		{
//		},

//		OnDeleteCookie = (context) =>
//		{

//		},

//		//ConsentCookie

//		CheckConsentNeeded = context => true,

//		Secure =
//			Microsoft.AspNetCore.Http.CookieSecurePolicy.Always,

//		//Secure =
//		//app.Environment.IsDevelopment()
//		//? Microsoft.AspNetCore.Http.CookieSecurePolicy.None:
//		//Microsoft.AspNetCore.Http.CookieSecurePolicy.Always
//	};

//// UseCookiePolicy() -> using Microsoft.AspNetCore.Builder;
//app.UseCookiePolicy(options: cookiePolicyOptions);
// **************************************************

// **************************************************
// Step (3)
// **************************************************
// UseAuthentication() -> using Microsoft.AspNetCore.Builder;
app.UseAuthentication();

// Note: [Authorize] Attribute Does not work!
// We should activate Step (4)
// **************************************************

// **************************************************
// Step (4)
// **************************************************
// UseAuthentication() -> using Microsoft.AspNetCore.Builder;
app.UseAuthorization();
// **************************************************

// **************************************************
// MapRazorPages() -> using Microsoft.AspNetCore.Builder;
app.MapRazorPages();
// **************************************************

// **************************************************
app.Run();
// **************************************************
