using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Blog.Data;
using Blog.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BlogDbContext") ?? throw new InvalidOperationException("Connection string 'BlogDbContext' not found.")));
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BlogDbContext>();
var app = builder.Build();
app.UseMvcWithDefaultRoute();
app.UseAuthentication();
try
{
    var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    ctx.Database.EnsureCreated();

    var adminRole = new IdentityRole("Admin");
    if (!ctx.Roles.Any())
    {
        roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
    }
    if (!ctx.Users.Any(u => u.UserName == "admin"))
    {
        var adminUser = new IdentityUser
        {
            UserName = "admin",
            Email = "admin@test.com"
        };

        userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
        userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}


app.Run();

