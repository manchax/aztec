using AztecDateTranslator.Shared;
using AztecDateTranslator.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DateTranslatorVM = AztecDateTranslator.ViewModels.DateTranslator;

namespace AztecDateTranslator
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddDbContext<AztecContext>();            
            builder.Services.AddPooledDbContextFactory<AztecContext>(options =>
                options.UseSqlite($"Data Source={AztecContext.DbPath}"));

            builder.Services.AddTransient<IDateTranslator, DateTranslator>();
            builder.Services.AddScoped<DateTranslatorVM>();

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AztecContext>();
            dbContext.Initialize();
            return app;
        }
    }
}
