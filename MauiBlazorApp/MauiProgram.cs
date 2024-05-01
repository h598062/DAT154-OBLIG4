using DatabaseLibrary.Context;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MauiBlazorApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddDbContextFactory<Oblig4Context>(options =>
            options.UseSqlServer("Server=tcp:dat154-2024-gruppe13.database.windows.net,1433;Initial Catalog=oblig4;Persist Security Info=False;User ID=bigggusdikkus;Password=Belletiss2024!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}