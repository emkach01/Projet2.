var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache(); // ← AJOUTÉ : active le cache en mémoire

builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddHttpClient<MovieService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();