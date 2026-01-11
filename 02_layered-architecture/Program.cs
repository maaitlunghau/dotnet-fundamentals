using _02_layered_architecture;
using _02_layered_architecture.Repository;
using _02_layered_architecture.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectedDB"));
});
// AddScoped = 1 request -> 1 instance (Repo, Service, DbContext)
builder.Services.AddScoped<IProductRepository, ProductService>();

// mở rộng thêm:
//      AddTransient = 1 inject -> 1 instance (stateless)
//      AddSingleton = 1 app -> 1 instance (cache, config)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
