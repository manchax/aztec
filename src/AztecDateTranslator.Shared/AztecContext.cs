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
        options.UseSqlite($"Data Source={_dbPath}");
        base.OnConfiguring(options);
    }
}