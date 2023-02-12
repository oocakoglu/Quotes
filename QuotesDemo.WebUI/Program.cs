using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuotesDemo.Core;
using QuotesDemo.Core.Services;
using QuotesDemo.Data;
using QuotesDemo.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IQuoteService, QuoteService>();

var _connectionString = builder.Configuration.GetConnectionString("QuoteDBConnection");
builder.Services.AddDbContext<QuoteDbContext> (option => option.UseSqlServer(_connectionString));
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quote}/{action=Index}/{id?}");

app.Run();
