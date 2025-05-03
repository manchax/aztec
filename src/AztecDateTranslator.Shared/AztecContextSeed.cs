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
            Mayan = "Imix",
            Spanish = "Cocodrilo",
            English = "Alligator"
        },
        new DaySign {
            DayNumber = 2,
            Nagual = Naguales.Wind,
            Nahuatl = "Ehécatl",
            Mayan = "Ik",
            Spanish = "Cocodrilo",
            English = "Alligator"
        },
        new DaySign {
            DayNumber = 3,
            Nagual = Naguales.House,
            Nahuatl = "Calli",
            Mayan = "Akbal",
            Spanish = "Casa",
            English = "House"
        },
        new DaySign {
            DayNumber = 4,
            Nagual = Naguales.Lizard,
            Nahuatl = "Cuetzpallin",
            Mayan = "Kan",
            Spanish = "Lagartija",
            English = "Lizard"
        },
        new DaySign {
            DayNumber = 5,
            Nagual = Naguales.Serpent,
            Nahuatl = "Cóatl",
            Mayan = "Chicchan",
            Spanish = "Serpiente",
            English = "Serpent"
        },
        new DaySign {
            DayNumber = 6,
            Nagual = Naguales.Death,
            Nahuatl = "Miquiztli",
            Mayan = "Cimi",
            Spanish = "Muerte",
            English = "Death"
        },
        new DaySign {
            DayNumber = 7,
            Nagual = Naguales.Deer,
            Nahuatl = "Mazatl",
            Mayan = "Manik",
            Spanish = "Venado",
            English = "Deer"
        },
        new DaySign {
            DayNumber = 8,
            Nagual = Naguales.Rabbit,
            Nahuatl = "Tochtli",
            Mayan = "Lamat",
            Spanish = "Conejo",
            English = "Rabbit"
        },
        new DaySign {
            DayNumber = 9,
            Nagual = Naguales.Water,
            Nahuatl = "Atl",
            Mayan = "Muluc",
            Spanish = "Agua",
            English = "Water"
        },
        new DaySign {
            DayNumber = 10,
            Nagual = Naguales.Dog,
            Nahuatl = "Itzcuintli",
            Mayan = "Oc",
            Spanish = "Perro",
            English = "Dog"
        },
        new DaySign {
            DayNumber = 11,
            Nagual = Naguales.Monkey,
            Nahuatl = "Ozomatli",
            Mayan = "Chuen",
            Spanish = "Mono",
            English = "Monkey"
        },
        new DaySign {
            DayNumber = 12,
            Nagual = Naguales.Grass,
            Nahuatl = "Malinali",
            Mayan = "Eb",
            Spanish = "Hierba",
            English = "Grass"
        },
        new DaySign {
            DayNumber = 13,
            Nagual = Naguales.Reed,
            Nahuatl = "Ácatl",
            Mayan = "Ben",
            Spanish = "Carrizo",
            English = "Reed"
        },
        new DaySign {
            DayNumber = 14,
            Nagual = Naguales.Ocelot,
            Nahuatl = "Ocelotl",
            Mayan = "Ix",
            Spanish = "Ocelote",
            English = "Ocelot"
        },
        new DaySign {
            DayNumber = 15,
            Nagual = Naguales.Eagle,
            Nahuatl = "Cuauhtli",
            Mayan = "Men",
            Spanish = "Águila",
            English = "Eagle"
        },
        new DaySign {
            DayNumber = 16,
            Nagual = Naguales.Vulture,
            Nahuatl = "Cozcacuahtli",
            Mayan = "Cib",
            Spanish = "Buitre",
            English = "Vulture"
        },
        new DaySign {
            DayNumber = 17,
            Nagual = Naguales.Movement,
            Nahuatl = "Ollin",
            Mayan = "Caban",
            Spanish = "Movimiento",
            English = "Movement"
        },
        new DaySign {
            DayNumber = 18,
            Nagual = Naguales.Knife,
            Nahuatl = "Tecpatl",
            Mayan = "Etznab",
            Spanish = "Cuchillo",
            English = "Knife"
        },
        new DaySign {
            DayNumber = 19,
            Nagual = Naguales.Rain,
            Nahuatl = "Quiahuitl",
            Mayan = "Cauac",
            Spanish = "Lluvia",
            English = "Rain"
        },
        new DaySign {
            DayNumber = 20,
            Nagual = Naguales.Flower,
            Nahuatl = "Xóchitl",
            Mayan = "Ahau",
            Spanish = "Flor",
            English = "Flower"
        }
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