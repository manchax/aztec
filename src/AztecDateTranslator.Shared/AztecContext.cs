using AztecDateTranslator.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace AztecDateTranslator.Shared;

public partial class AztecContext : DbContext
{
    private static readonly string dbPath;

    /// <summary>
    /// Sets sqlite db path.
    /// </summary>
    static AztecContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        dbPath = Path.Join(path, "aztec.db");
    }

    public DbSet<DaySign> DaySigns { get; set; }

    public DbSet<Cempohuallapohualli> Cempohuallapohuallis { get; set; }

    public static string DbPath => dbPath;

    /// <summary>
    /// on new installs creates db, otherwise, runs updates on existing db file
    /// </summary>    
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