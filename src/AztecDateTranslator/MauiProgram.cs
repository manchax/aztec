using AztecDateTranslator.Shared;
using AztecDateTranslator.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;

#if DEBUG && WINDOWS
using Microsoft.Maui.LifecycleEvents;
using System.Diagnostics;
#endif
using DateTranslatorVM = AztecDateTranslator.ViewModels.DateTranslator;

namespace AztecDateTranslator
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var esMX = CultureInfo.GetCultureInfo("es-MX");
            CultureInfo.CurrentCulture = esMX;
            CultureInfo.CurrentUICulture = esMX;
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
#if !ANDROID && !IOS && !MACCATALYST && !WINDOWS
                .UseAvaloniaApp()
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
#if !(DEBUG && WINDOWS)
            ;
#else
            .ConfigureLifecycleEvents(static e =>
            {
                e.AddWindows(w => w.OnWindowCreated(window =>
                    window.SizeChanged += (_, e) =>
                        Debug.WriteLine("Window size changed. " +
                            $"Width: {e.Size.Width}, Height: {e.Size.Height}")
                ));
            });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddDbContext<AztecContext>(); // EF setup (database)
            builder.Services.AddTransient<IDateTranslator, DateTranslator>(); // Service
            builder.Services.AddScoped<DateTranslatorVM>(); // ViewModel

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AztecContext>();
            dbContext.Initialize(); // make sure database is created and seeded
            return app;
        }
    }
}
