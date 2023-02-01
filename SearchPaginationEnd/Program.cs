using Microsoft.EntityFrameworkCore;
using SearchPaginationEnd.Models;
using SearchPaginationEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// L�gg till min DbContext
builder.Services.AddDbContext<NorthwindContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// L�gg till min SupplierService
builder.Services.AddTransient<ISupplierService, SupplierService>();
// L�gg till min CategoryService
builder.Services.AddTransient<ICategoryService, CategoryService>();
// L�gg till min ProductService
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
