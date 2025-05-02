using AztecDateTranslator.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AztecDateTranslator.Shared;

internal class AztecContext : DbContext
{
    private readonly string _dbPath;
    public AztecContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _dbPath = Path.Join(path, "aztec.db");
    }
    public DbSet<DaySign> DaySigns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={_dbPath}");
        base.OnConfiguring(options);
    }
}