using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CourseSocialMedia.Data;

using CourseSocialMedia.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
		.AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages(options => {
		options.Conventions.AuthorizeFolder("/Admin", "Admin");
});

builder.Services.AddAuthorization(options => {
		options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

// builder.Services.AddRazorPages();

var app = builder.Build();

async Task CreateRoles(IServiceProvider serviceProvider)
{
	RoleManager<ApplicationRole> roleManager =  serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

	string[] roleNames = { "Admin", "User" };

	foreach (string roleName in roleNames)
	{
		bool roleExists = await roleManager.RoleExistsAsync(roleName);

		if (!roleExists)
		{
			await roleManager.CreateAsync(new ApplicationRole(roleName));
		}
	}
}

using (var scope = app.Services.CreateScope())
{
	IServiceProvider serviceProvider = scope.ServiceProvider;
	await CreateRoles(serviceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapRazorPages();

app.Run();
