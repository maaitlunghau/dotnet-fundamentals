using _11_dto_automapper_authentication.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/**
 * Nội dung lesson này:
 * -- DTO automapper
 * -- Authentication (mức độ đơn giản, kco token hay cookie, ...)
 *
 * Chức năng chính:
 * + Quản lý tài khoản của người dùng (Account) -> Index, Create
 * + Xử lí authentication (login, logout, kiểm tra nguời dùng đã login chưa khi vào Index)
 *
 * - Chủ yếu kiến thức cũ, code Controller, không dùng DI
 * - Kiến thức mới:
 *      + Biết cách làm DTO automapper
 *      + dùng Session để lưu thông tin người dùng đã login
 *      + dùng JsonConvert để parse string <--> JSON 
 *      (cài thêm thư viện Newtonsoft.Json / parse core)
 *
 * => Bài học rút ra:
 *      -- Dùng DTO automapper thấy cực hơn là dùng DTO mapping thủ công
 *      -- Chỉ nên dùng DTO automapper khi phạm vi project lớn
 *      -- Khi 2 model quá khác nhau về field hoặc project nhỏ thì nên ưu tiên dùng mapping thủ công hơn
 *
 *
 * ----- Bài tập về nhà -----:
 * + xử lí thêm: logout quá 3 lần => ban luôn account (phải có message thông báo cho user)
 * + trong Index, thêm hiển thị trạng thái (status) của user, nếu user nào bị ban thì sẽ có button 'Unban' để gỡ ban cho user 
*/

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectedDB"))
);

// kh đăng ký DI container để cho đơn giản

// cấu hình session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAutoMapper(typeof(MapperProfile)); // nếu lỗi dòng này thì cài thêm package AutoMapper phiên bản có DI nữa là hết

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

app.UseSession(); // gọi để sử dụng Session

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
