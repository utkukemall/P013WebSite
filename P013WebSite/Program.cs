using P013WebSite.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // Admin panelde authorize attribute � ile g�venlik sa�layabilmek i�in

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // Burada veritaban� i�lemleri i�in kulland���m�z contexti tan�t�yoruz
// veritaban� olu�turmak i�in list men�den Tools > Nuget Package Manager > Package Manager Console Men�s�nden komut yazma ekran�n� a��yoruz.
// Bu ekrana add-migration InitialCreate yaz�p enter a bas�yoruz.
// Migration klas�r� ve initialcreate class � olu�tuktan sonra (add-migration InitialCreate yazd�oktan sonra) update-database yaz�p enter a bas�yoruz.
// Done mesaj� geldiyse i�lem ba�ar�l�d�r.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // Login sisteminin varsay�lan login giri� adresini kendi adresimizle de�i�tiriyoruz
    x.Cookie.Name = "AdminLogin"; // Oturum i�in olu�acak cookie nin ismini belirledik 
}); // Admin panelde authorize attribute � ile g�venlik sa�layabilmek i�in 

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
