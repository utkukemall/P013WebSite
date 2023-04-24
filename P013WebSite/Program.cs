using P013WebSite.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // Admin panelde authorize attribute ü ile güvenlik saðlayabilmek için

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // Burada veritabaný iþlemleri için kullandýðýmýz contexti tanýtýyoruz
// veritabaný oluþturmak için list menüden Tools > Nuget Package Manager > Package Manager Console Menüsünden komut yazma ekranýný açýyoruz.
// Bu ekrana add-migration InitialCreate yazýp enter a basýyoruz.
// Migration klasörü ve initialcreate class ý oluþtuktan sonra (add-migration InitialCreate yazdýoktan sonra) update-database yazýp enter a basýyoruz.
// Done mesajý geldiyse iþlem baþarýlýdýr.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // Login sisteminin varsayýlan login giriþ adresini kendi adresimizle deðiþtiriyoruz
    x.Cookie.Name = "AdminLogin"; // Oturum için oluþacak cookie nin ismini belirledik 
}); // Admin panelde authorize attribute ü ile güvenlik saðlayabilmek için 

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
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
