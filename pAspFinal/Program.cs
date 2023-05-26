using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pAspFinal.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("pAspFinal_dbContextConnection") ?? throw new InvalidOperationException("Connection string 'pAspFinal_dbContextConnection' not found.");


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IQuestionRepository, BDQuestionRepository>();
builder.Services.AddScoped<ISectionRepository, BDSectionRepository>();
builder.Services.AddScoped<ITypeRepository, BDTypeRepository>();
builder.Services.AddScoped<IFormulaireRepository, BDFormulaireRepository>();

builder.Services.AddDbContext<pAspFinal_dbContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:pAspFinal_dbContextConnection"]);
});

builder.Services.AddIdentity<Utilisateur, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<pAspFinal_dbContext>().AddDefaultUI().AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

InitialiseurDB.Seed(app);

app.Run();
