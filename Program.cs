using Projet2_M.Services;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services MVC
builder.Services.AddControllersWithViews();

// Ajouter le cache mémoire
builder.Services.AddMemoryCache();

// Ajouter HttpClient pour les services
builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddHttpClient<MovieService>();

var app = builder.Build();

// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();