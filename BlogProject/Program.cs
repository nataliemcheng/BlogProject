using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlogProject.Data;
using BlogProject.Models;
using BlogProject.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<BlogUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Register custom DataService class
builder.Services.AddScoped<DataService>();

// Register a preconfigured instance of the MailSettings clas
builder.Services.Configure<BlogProject.ViewModels.MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IBlogEmailSender, EmailService>();

// Register Image Service
builder.Services.AddScoped<IImageService, BasicImageService>();

// Register Slug Service
builder.Services.AddScoped<ISlugService, BasicSlugService>();


var app = builder.Build();

//pull out registered DataService
var dataService = app.Services
                     .CreateScope().ServiceProvider
                     .GetRequiredService<DataService>();

await dataService.ManageDataAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
