using P013WebSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // Burada veritaban� i�lemleri i�in kulland���m�z contexti tan�t�yoruz
// veritaban� olu�turmak i�in list men�den Tools > Nuget Package Manager > Package Manager Console Men�s�nden komut yazma ekran�n� a��yoruz.
// Bu ekrana add-migration InitialCreate yaz�p enter a bas�yoruz.
// Migration klas�r� ve initialcreate class � olu�tuktan sonra (add-migration InitialCreate yazd�oktan sonra) update-database yaz�p enter a bas�yoruz.
// Done mesaj� geldiyse i�lem ba�ar�l�d�r.

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
