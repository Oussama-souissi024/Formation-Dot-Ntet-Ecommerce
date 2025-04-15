using Formationn_Ecommerce.Core.Interfaces.Repositories;
using Formationn_Ecommerce.Infrastucture.Extension;
using Formationn_Ecommerce.Infrastucture.Persistence;
using Formationn_Ecommerce.Infrastucture.Persistence.DbInitializer;
using Formationn_Ecommerce.Application.Common.Extension;
using Microsoft.EntityFrameworkCore;
using Formationn_Ecommerce.Mapping.Coupon;
using Formationn_Ecommerce.Mapping.Category;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add DBContext with explicit SQL Server configuration
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DeafaultConnection")));

builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddServiceRegistraion();
builder.Services.AddAutoMapper(typeof(CouponMappingProfile));
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));

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

// Initialize database with seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    // Use Wait() instead of await since this is not an async method
    DbInitializer.InitializeDatabase(dbContext).Wait();
}

app.Run();
