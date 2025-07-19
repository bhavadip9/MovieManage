using Microsoft.EntityFrameworkCore;
using MovieManage.Middleware;
using MovieManage.Models;
using MovieManage.Repository.Implementation;
using MovieManage.Repository.Interfaces;
using MovieManage.Service.Implementation;
using MovieManage.Service.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(); // ✅ Required for session support

var conn = builder.Configuration.GetConnectionString("UserMovieDB");
builder.Services.AddDbContext<UserMovieDbContext>(q => q.UseSqlServer(conn));

// Dependency injections
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepostory, MovieRepository>();
builder.Services.AddScoped<LoginCheckFilter>();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();      // ✅ Correct replacement for MapStaticAssets
app.UseRouting();

app.UseSession();          // ✅ Enable session
app.UseAuthentication();   // ❓ Optional based on your JWT usage
app.UseAuthorization();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddHttpContextAccessor();

//var conn = builder.Configuration.GetConnectionString("UserMovieDB");
//builder.Services.AddDbContext<UserMovieDbContext>(q => q.UseSqlServer(conn));


//builder.Services.AddScoped<ICookieService, CookieService>();
//builder.Services.AddScoped<IJwtService, JwtService>();
//builder.Services.AddScoped<ISessionService, SessionService>();
//builder.Services.AddScoped<ILoginRepository, LoginRepository>();
//builder.Services.AddScoped<ILoginService, LoginService>();

//builder.Services.AddScoped<LoginCheckFilter>();




//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseRouting();
//app.UseAuthorization();
//app.MapStaticAssets();
//app.UseSession();
//app.UseAuthentication();

////app.MapControllerRoute(
////    name: "default",
////    pattern: "{controller=Home}/{action=Index}/{id?}")
////    .WithStaticAssets();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Login}/{action=Login}/{id?}");

//app.Run();
