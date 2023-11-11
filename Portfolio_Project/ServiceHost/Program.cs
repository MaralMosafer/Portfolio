using _0_Framework.Application;
using AccountManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectManagement.Configuration;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
       .AddRazorPagesOptions(options =>
        {
            options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
        });
{
    PortfolioManagementBootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("PortfolioDB"));
    AccountManagementBootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("PortfolioDB"));
    builder.Services.AddTransient<IFileUploader, FileUploader>();
    builder.Services.AddHttpContextAccessor();


    #region Login Register
    builder.Services.Configure<CookiePolicyOptions>(options =>
    {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.Lax;
    });

    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
        {
            o.LoginPath = new PathString("/Login");
            o.LogoutPath = new PathString("/Login");
            o.AccessDeniedPath = new PathString("/AccessDenied");
        });
    #endregion

    #region Authorization
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminArea",
            builder => builder.RequireRole(new List<string> { RoleType.Administrator.ToString() }));
    });
    #endregion
}

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.MapRazorPages();

app.Run();
