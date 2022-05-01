using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
builder.Services
	.AddAuthentication(defaultScheme: "Googooli")
	.AddCookie(authenticationScheme: "Googooli", options =>
	{
		options.LoginPath = "/Account/Login";
		options.LogoutPath = "/Account/Logout";
		options.AccessDeniedPath = "/Account/AccessDenied";

		//options.Cookie.Path;
		//options.Cookie.Domain;
		//options.Cookie.MaxAge;
		//options.Cookie.HttpOnly;
		//options.Cookie.SameSite;
		//options.Cookie.Expiration;
		//options.Cookie.IsEssential;
		//options.Cookie.SecurePolicy;
		options.Cookie.Name = "Googooli";

		options.ClaimsIssuer = "DTAT";

		//options.SessionStore
		//options.ExpireTimeSpan
		//options.TicketDataFormat
		options.SlidingExpiration = true;
		options.ReturnUrlParameter = "ReturnUrl";

		//options.ForwardSignIn
		//options.ForwardForbid
		//options.ForwardDefault
		//options.ForwardSignOut
		//options.ForwardChallenge
		//options.ForwardAuthenticate
		//options.ForwardDefaultSelector

		//options.CookieManager
		//options.DataProtectionProvider

		//options.Events
		//options.EventsType

		options.Validate();
	});

// Note: Does not work!
// We should activate Step (3)
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
