using DatabaseAccess;
using Microsoft.AspNetCore.Identity;
using Model;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipes;
using DataService.Interface;
using DataService.Implementation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomNumberService, RoomNumberService>();
builder.Services.AddScoped<IAmenityService, AmenityService>();
builder.Services.AddScoped<IRoomAmenityService, RoomAmenityService>();
builder.Services.AddScoped<IWorker, Worker>();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();


builder.Services.AddMvc().AddViewOptions(options => options.HtmlHelperOptions.FormInputRenderMode = FormInputRenderMode.AlwaysUseCurrentCulture);

builder.Services.Configure<IdentityOptions>(opt =>
{

    opt.Password.RequiredLength = 6;
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequireUppercase = true;
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
