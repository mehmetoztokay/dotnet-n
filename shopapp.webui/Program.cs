using shopapp.business.Concrete;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductRepository, EFCoreProductRepository>();
// IProductRepository cagirildiginda EFCoreProductRepository gondermek istedigimizi soyledik.
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    SeedDatabase.Seed();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();