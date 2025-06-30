using AztecDateTranslator.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace AztecDateTranslator.Shared;

public partial class AztecContext : DbContext
{
    private static readonly string dbPath;

    static AztecContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        dbPath = Path.Join(path, "aztec.db");
    }

    public DbSet<DaySign> DaySigns { get; set; }

    public DbSet<Cempohuallapohualli> Cempohuallapohuallis { get; set; }

    public static string DbPath => dbPath;

    public void Initialize()
    {
        if (!File.Exists(dbPath))
        {
            Database.EnsureCreated();
        }
        else
        {
            Database.Migrate();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={dbPath}")
            .EnableSensitiveDataLogging()
            .UseSeeding((context, _) =>
            {
                AddDaySigns(context.Set<DaySign>());
                AddCempohuallapohuallis(context.Set<Cempohuallapohualli>());
                context.SaveChanges();
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                await AddDaySignsAsync(context.Set<DaySign>());
                await AddCempohuallapohuallisAsync(context.Set<Cempohuallapohualli>());
                await context.SaveChangesAsync(cancellationToken);
            });

        base.OnConfiguring(options);
    }
}