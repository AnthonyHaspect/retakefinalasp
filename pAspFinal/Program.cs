using Microsoft.EntityFrameworkCore;
using pAspFinal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<pAspFinal_dbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:pAspFinal_dbContextConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

InitialiseurDB.Seed(app);

app.Run();
