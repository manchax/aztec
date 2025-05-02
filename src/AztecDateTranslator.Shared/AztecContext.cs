using AztecDateTranslator.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AztecDateTranslator.Shared;

public class AztecContext : DbContext
{
    private static readonly string _dbPath;

    static AztecContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _dbPath = Path.Join(path, "aztec.db");
    }

    public DbSet<DaySign> DaySigns { get; set; }

    public static string DbPath => _dbPath;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={_dbPath}")
            .EnableSensitiveDataLogging()
            .UseSeeding((context, _) =>
            {
                AddDaySigns(context);
                context.SaveChanges();
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                await AddDaySignsAsync(context);
                await context.SaveChangesAsync(cancellationToken);
            });

        base.OnConfiguring(options);
    }

    private void AddDaySigns(DbContext dbContext)
    {
        var dbSet = dbContext.Set<DaySign>();
        dbSet.AddRange([
            new DaySign
            {
                DayNumber = 1,
                Nagual = Naguales.Alligator,
                Nahuatl = "Cipactli",
                Spanish = "Cocodrilo",
                English = "Alligator"
            },
            new DaySign
            {
                DayNumber = 2,
                Nagual = Naguales.Wind,
                Nahuatl = "Ehécatl",
                Spanish = "Cocodrilo",
                English = "Alligator"
            },
            new DaySign{
                DayNumber = 3,
                Nagual = Naguales.House,
                Nahuatl = "Calli",
                Spanish = "Casa",
                English = "House"
            }
        ]);
    }

    private async Task AddDaySignsAsync(DbContext dbContext)
    {
        var dbSet = dbContext.Set<DaySign>();
        await dbSet.AddRangeAsync([]);
    }
}