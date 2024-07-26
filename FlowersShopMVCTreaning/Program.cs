using FlowersShopMVCTraining.Controllers;
using FlowersShopMVCTraining.Repository;
using FlowersShopMVCTraining.Repository.Repository;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service;
using FlowersShopMVCTraining.Service.AuthStuff;
using FlowersShopMVCTrainingRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHostedService<ImageProcessingService>();

builder.Services
    .AddAuthentication(AuthUserController.AUTH_METHOD)
    .AddCookie(AuthUserController.AUTH_METHOD, option =>
    {
        option.LoginPath = "/AuthUser/Login";
    });

builder.Services.AddDbContext<FlowersShopDbContext>(x => x.UseSqlServer(FlowersShopDbContext.CONNECTION_STRING));

//Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductDescriptionRepository,ProductDescriptionRepository>();
builder.Services.AddScoped<IShopCardRepository,ShopCardRepository>();

// Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<HashingService>();
builder.Services.AddSingleton<PathHelper>();

builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var env = services.GetRequiredService<IWebHostEnvironment>();
    var seed = new Seed();
    seed.Fill(services, env.WebRootPath);
}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.Run();
