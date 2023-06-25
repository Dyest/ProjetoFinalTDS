using System.Globalization;
using delivery.Data;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();


app.Run();

app.UseAuthorization();

app.MapRazorPages();


var defaultCulture = new CultureInfo ("pt-BR");
    var localizationOptions = new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture(defaultCulture),
        SupportedCultures = new List<CultureInfo> {defaultCulture},
        SupportedUICultures = new List<CultureInfo> {defaultCulture}
    };
    app.UseRequestLocalization(localizationOptions);

app.Run();
