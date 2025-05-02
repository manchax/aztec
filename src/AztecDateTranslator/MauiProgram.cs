using AztecDateTranslator.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            // builder.AddLogging(options => options.AddDebug())
            builder.Services.AddPooledDbContextFactory<AztecContext>(options =>
                options.UseSqlite($"Data Source={AztecContext.DbPath}"));

            return builder.Build();
        }
    }
}
