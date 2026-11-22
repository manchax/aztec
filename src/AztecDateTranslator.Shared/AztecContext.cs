using AztecDateTranslator.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
        var path = Path.Combine(Environment.GetFolderPath(folder),
            "AztecDateTranslator");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
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
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.MigrationsNotFound))
            .EnableSensitiveDataLogging()
            .UseSeeding((context, _) =>
            {
                var daySigns = context.Set<DaySign>();
                var cempohuallis = context.Set<Cempohuallapohualli>();
                if (daySigns.Count() != 20)
                {
                    daySigns.ExecuteDelete();
                    AddDaySigns(daySigns);
                }

                if (cempohuallis.Count() != 19)
                {
                    cempohuallis.ExecuteDelete();
                    AddCempohuallapohuallis(cempohuallis);
                }

                context.SaveChanges();
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                var daySigns = context.Set<DaySign>();
                var cempohuallis = context.Set<Cempohuallapohualli>();
                if (await daySigns.CountAsync(cancellationToken) != 20)
                {
                    await daySigns.ExecuteDeleteAsync(cancellationToken);
                    await AddDaySignsAsync(daySigns, cancellationToken);
                }

                if (await cempohuallis.CountAsync(cancellationToken) != 19)
                {
                    await cempohuallis.ExecuteDeleteAsync(cancellationToken);
                    await AddCempohuallapohuallisAsync(cempohuallis, cancellationToken);
                }

                await context.SaveChangesAsync(cancellationToken);
            });

        base.OnConfiguring(options);
    }
}