using AztecDateTranslator.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AztecDateTranslator.Shared;

public partial class AztecContext
{
    private readonly IEnumerable<DaySign> _signs = [
        new DaySign {
            DayNumber = 1,
            Nagual = Naguales.Alligator,
            Nahuatl = "Cipactli",
            Spanish = "Cocodrilo",
            English = "Alligator"
        },
        new DaySign {
            DayNumber = 2,
            Nagual = Naguales.Wind,
            Nahuatl = "Ehécatl",
            Spanish = "Cocodrilo",
            English = "Alligator"
        },
        new DaySign {
            DayNumber = 3,
            Nagual = Naguales.House,
            Nahuatl = "Calli",
            Spanish = "Casa",
            English = "House"
        },
        new DaySign {
            DayNumber = 4,
            Nagual = Naguales.Lizard,
            Nahuatl = "Cuetzpallin",
            Spanish = "Lagartija",
            English = "Lizard"
        },
        new DaySign {
            DayNumber = 5,
            Nagual = Naguales.Serpent,
            Nahuatl = "Cóatl",
            Spanish = "Serpiente",
            English = "Serpent"
        },
    ];

    private void AddDaySigns(DbContext dbContext)
    {
        var dbSet = dbContext.Set<DaySign>();
        dbSet.AddRange(_signs);
    }

    private async Task AddDaySignsAsync(DbContext dbContext)
    {
        var dbSet = dbContext.Set<DaySign>();
        await dbSet.AddRangeAsync(_signs);
    }
}
