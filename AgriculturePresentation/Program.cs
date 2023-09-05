using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configurations

////Service Configuration
//builder.Services.AddScoped<IServiceService, ServiceManager>();
//builder.Services.AddScoped<IServiceDal, EfServiceDal>();

////Team Configuration
//builder.Services.AddScoped<ITeamService, TeamManager>();
//builder.Services.AddScoped<ITeamDal, EfTeamDal>();

////Announcement Configuration
//builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
//builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

////Image Configuration
//builder.Services.AddScoped<IImageService, ImageManager>();
//builder.Services.AddScoped<IImageDal, EfImageDal>();

////Address Configuration
//builder.Services.AddScoped<IAddressService, AddressManager>();
//builder.Services.AddScoped<IAddressDal, EfAddressDal>();

////Contact Configuration
//builder.Services.AddScoped<IContactService, ContactManager>();
//builder.Services.AddScoped<IContactDal, EfContactDal>();

////SocialMedia Configuration
//builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
//builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

////About Configuration
//builder.Services.AddScoped<IAboutService, AboutManager>();
//builder.Services.AddScoped<IAboutDal, EfAboutDal>();

////Admin Configuration
//builder.Services.AddScoped<IAdminService, AdminManager>();
//builder.Services.AddScoped<IAdminDal, EfAdminDal>();

#endregion


builder.Services.AddDbContext<AgricultureContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AgricultureContext>();

builder.Services.ContainerDependencies();

builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults
    .AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index/";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();    

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
