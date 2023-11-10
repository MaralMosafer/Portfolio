using _0_Framework.Application;
using AccountManagement.Configuration;
using ProjectManagement.Configuration;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
{
    PortfolioManagementBootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("PortfolioDB"));
    AccountManagementBootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("PortfolioDB"));
    builder.Services.AddTransient<IFileUploader, FileUploader>();
    builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
