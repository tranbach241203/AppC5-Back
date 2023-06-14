using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


////Add services to the container.
//builder.Services.AddControllersWithViews();

//builder.Services.AddAuthentication(
//	CookieAuthenticationDefaults.AuthenticationScheme)
//	.AddCookie(option =>
//	{
//		option.LoginPath = "/Account/Login";
//		option.ExpireTimeSpan = TimeSpan.FromMinutes(20);

//	});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
	// DefaultAuthenticateScheme: Đây là Scheme sẽ được sử dụng để xác thực yêu cầu đã được xác thực thành công.
	// Trong trường hợp này,CookieAuthenticationDefaults.AuthenticationScheme  được sử dụng, điều này có nghĩa là sử dụng xác thực bằng cookie.
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})

 // cau hinh cookie
 .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
 {
	 options.Cookie.Name = "User";
	 options.LoginPath = "/Account/Login";
	 options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Thiết lập chính sách bảo mật
	 options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Thiết lập thời gian sống của cookie
	 options.SlidingExpiration = true; // Cho phép cookie được cập nhật thời gian sống mỗi khi có request mới
	 options.Cookie.HttpOnly = true;
 });

var sessionTimes = new Dictionary<string, TimeSpan>()
{
	{"Session_Key1", new TimeSpan(0, 30, 0)}, // 30p
    {"Session_Key2", new TimeSpan(0, 30, 0)}, // 3s 
    {"Session_Key", new TimeSpan(0, 30, 0)}, // 3s 
};


// Đăng ký session vào dịch vụ
builder.Services.AddSession(options =>
{
	foreach (var key in sessionTimes.Keys)
	{
		TimeSpan duration;
		if (sessionTimes.TryGetValue(key, out duration))
		{
			options.IdleTimeout = duration;
		}
	}
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.UseSession();

app.Run();
