using DatabaseAccess;
using Microsoft.AspNetCore.Identity;
using Model;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipes;
using DataService.Interface;
using DataService.Implementation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;
using Repository.Interface;
using Repository.Implementation;
using sib_api_v3_sdk.Client;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomNumberService, RoomNumberService>();
builder.Services.AddScoped<IAmenityService, AmenityService>();
builder.Services.AddScoped<IRoomAmenityService, RoomAmenityService>();
builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddScoped<IDashboardService,DashboardService>();
builder.Services.AddScoped<IResetPasswordService, ResetPasswordService>();
builder.Services.AddScoped<IWorker, Worker>();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IHelper, Helper>();

Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoSettings:ApiKey"]);


builder.Services.AddIdentityCore<ApplicationUser>(option => option.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


builder.Services.AddMvc().AddViewOptions(options => options.HtmlHelperOptions.FormInputRenderMode = FormInputRenderMode.AlwaysUseCurrentCulture);

builder.Services.Configure<IdentityOptions>(opt =>
{

    opt.Password.RequiredLength = 6;
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequireUppercase = true;
});

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();


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
SeedDatabase();





    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDBInitializer>();
        dbInitializer.Initialize();

    }
}
