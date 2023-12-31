using DataAccess;
using DataAccessServiceContract;
using DomainModel;
using DomainModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region Contexxt

const string connectionString =
    // "Data Source=DESKTOP-GROJMHH;Initial Catalog=FirstProjectTest;User ID=sa;Password=whoamia;MultipleActiveResultSets=true;TrustServerCertificate=Yes;";
    "Data Source=192.168.1.227;Initial Catalog=ATestt;User ID=sa;Password=DaT@BA$3$Rv;MultipleActiveResultSets=true;TrustServerCertificate=Yes";
builder.Services.AddDbContext<PersonalContext>(options => options.UseSqlServer(connectionString));

#endregion

#region IOC

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RolRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<ISectionUserLayoutRepository, SectionUserLayoutRepository>();
builder.Services.AddScoped<IUserLayoutRepository, UserLayoutRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<UserManager<Users>>();
builder.Services.AddScoped<SignInManager<Users>>();

#endregion

#region Auth

builder
    .Services
    .AddIdentity<Users, Role>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<PersonalContext>()
    .AddDefaultTokenProviders();

builder
    .Services
    .ConfigureApplicationCookie(options =>
    {
        options.AccessDeniedPath = "/Login";
        options.LogoutPath = "/Logout";
        options.LoginPath = "/Login";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
    });

#endregion


builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/FourZeroFour");
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
