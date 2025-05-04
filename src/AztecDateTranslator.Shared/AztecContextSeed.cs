using AztecDateTranslator.Shared.Entities;
using AztecDateTranslator.Shared.Model;
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
            English = "Alligator",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 2,
            Nagual = Naguales.Wind,
            Nahuatl = "Ehécatl",
            Mayan = "Ik",
            Spanish = "Viento",
            English = "Wind",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 3,
            Nagual = Naguales.House,
            Nahuatl = "Calli",
            Mayan = "Akbal",
            Spanish = "Casa",
            English = "House",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 4,
            Nagual = Naguales.Lizard,
            Nahuatl = "Cuetzpallin",
            Mayan = "Kan",
            Spanish = "Lagartija",
            English = "Lizard",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 5,
            Nagual = Naguales.Serpent,
            Nahuatl = "Cóatl",
            Mayan = "Chicchan",
            Spanish = "Serpiente",
            English = "Serpent",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 6,
            Nagual = Naguales.Death,
            Nahuatl = "Miquiztli",
            Mayan = "Cimi",
            Spanish = "Muerte",
            English = "Death",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 7,
            Nagual = Naguales.Deer,
            Nahuatl = "Mazatl",
            Mayan = "Manik",
            Spanish = "Venado",
            English = "Deer",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 8,
            Nagual = Naguales.Rabbit,
            Nahuatl = "Tochtli",
            Mayan = "Lamat",
            Spanish = "Conejo",
            English = "Rabbit",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 9,
            Nagual = Naguales.Water,
            Nahuatl = "Atl",
            Mayan = "Muluc",
            Spanish = "Agua",
            English = "Water",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 10,
            Nagual = Naguales.Dog,
            Nahuatl = "Itzcuintli",
            Mayan = "Oc",
            Spanish = "Perro",
            English = "Dog",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 11,
            Nagual = Naguales.Monkey,
            Nahuatl = "Ozomatli",
            Mayan = "Chuen",
            Spanish = "Mono",
            English = "Monkey",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 12,
            Nagual = Naguales.Grass,
            Nahuatl = "Malinali",
            Mayan = "Eb",
            Spanish = "Hierba",
            English = "Grass",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 13,
            Nagual = Naguales.Reed,
            Nahuatl = "Ácatl",
            Mayan = "Ben",
            Spanish = "Carrizo",
            English = "Reed",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 14,
            Nagual = Naguales.Ocelot,
            Nahuatl = "Ocelotl",
            Mayan = "Ix",
            Spanish = "Ocelote",
            English = "Ocelot",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 15,
            Nagual = Naguales.Eagle,
            Nahuatl = "Cuauhtli",
            Mayan = "Men",
            Spanish = "Águila",
            English = "Eagle",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 16,
            Nagual = Naguales.Vulture,
            Nahuatl = "Cozcacuahtli",
            Mayan = "Cib",
            Spanish = "Buitre",
            English = "Vulture",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 17,
            Nagual = Naguales.Movement,
            Nahuatl = "Ollin",
            Mayan = "Caban",
            Spanish = "Movimiento",
            English = "Movement",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 18,
            Nagual = Naguales.Knife,
            Nahuatl = "Tecpatl",
            Mayan = "Etznab",
            Spanish = "Cuchillo",
            English = "Knife",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 19,
            Nagual = Naguales.Rain,
            Nahuatl = "Quiahuitl",
            Mayan = "Cauac",
            Spanish = "Lluvia",
            English = "Rain",
            AztecDeity = ""
        },
        new DaySign {
            DayNumber = 20,
            Nagual = Naguales.Flower,
            Nahuatl = "Xóchitl",
            Mayan = "Ahau",
            Spanish = "Flor",
            English = "Flower",
            AztecDeity = ""
        }
    ];

    private readonly IEnumerable<Cempohuallapohualli> _months = [
        new Cempohuallapohualli {
            Number = 1,
            Name = "Cuahuitlehua", Maya = "Pop",
            Description = "",
            Deity = "Tláloc"
        },
        new Cempohuallapohualli {
            Number = 2,
            Name = "Cuahuitlehua", Maya = "Uo",
            Description = "",
            Deity = "Xipe Tótec"
        },
        new Cempohuallapohualli {
            Number = 3,
            Name = "Tozoztontli", Maya = "Zip",
            Description = "",
            Deity = "Coatlicue"
        },
        new Cempohuallapohualli {
            Number = 4,
            Name = "Huey Tozoztli", Maya = "Sots",
            Description = "",
            Deity = "Cintéotl-Chicomecóatl"
        },
        new Cempohuallapohualli {
            Number = 5,
            Name = "Tóxcatl", Maya = "Tsek",
            Description = "",
            Deity = "Tezcatlipoca-Huitzilopochtli"
        },
        new Cempohuallapohualli {
            Number = 6,
            Name = "Etzalcualiztli", Maya = "Xul",
            Description = "",
            Deity = "Tláloc"
        },
        new Cempohuallapohualli {
            Number = 7,
            Name = "Tecuilhuitontli", Maya = "Yaxkin",
            Description = "",
            Deity = "Huixtocíhuatl"
        },
        new Cempohuallapohualli {
            Number = 8,
            Name = "Huey Tecuilhuitl", Maya = "Mol",
            Description = "",
            Deity = "Xilonen-Xochipilli"
        },
        new Cempohuallapohualli {
            Number = 9,
            Name = "Tlaxochimaco", Maya = "Ch'en",
            Description = "",
            Deity = "Huitzilopochtli-Mictlantecuhtli"
        },
        new Cempohuallapohualli {
            Number = 10,
            Name = "Xocotlhuetzi", Maya = "Sak",
            Description = "",
            Deity = "Xiuhtecuhtli-Yacatecuhtl-Mictlantecuhtli"
        },
        new Cempohuallapohualli {
            Number = 11,
            Name = "Ochpaniztli", Maya = "Keh",
            Description = "Atlatonan-Chicomecóatl-Toci",
            Deity = ""
        },
        new Cempohuallapohualli {
            Number = 12,
            Name = "Teotleco", Maya = "Mac",
            Description = "",
            Deity = ""
        },
        new Cempohuallapohualli {
            Number = 13,
            Name = "Tepeilhuitl", Maya = "",
            Description = "",
            Deity = ""
        },
        new Cempohuallapohualli {
            Number = 14,
            Name = "Quecholli", Maya = "Kankin",
            Description = "",
            Deity = "Mixcóatl"
        },
        new Cempohuallapohualli {
            Number = 15,
            Name = "Panquetzaliztli", Maya = "Muwan",
            Description = "",
            Deity = "Huitzilopochtli"
        },
        new Cempohuallapohualli {
            Number = 16,
            Name = "Atemoztli", Maya = "Pax",
            Description = "",
            Deity = "Tláloc"
        },
        new Cempohuallapohualli {
            Number = 17,
            Name = "Títitl", Maya = "Kayab",
            Description = "",
            Deity = "Ilamatecuhtli-Mixcóatl"
        },
        new Cempohuallapohualli {
            Number = 18,
            Name = "Izcalli", Maya = "Cumkú",
            Description = "",
            Deity = "Xiuhtecutli"
        },
        new Cempohuallapohualli {
            Number = 19,
            Name = "Nemontemi", Maya = "Wayeb",
            Description = "",
            Deity = ""
        }];

    private void AddDaySigns(DbSet<DaySign> dbSet)
        => dbSet.AddRange(_signs);

    private async Task AddDaySignsAsync(DbSet<DaySign> dbSet)
        => await dbSet.AddRangeAsync(_signs);

    private void AddCempohuallapohuallis(DbSet<Cempohuallapohualli> dbSet)
        => dbSet.AddRange(_months);

    private async Task AddCempohuallapohuallisAsync(DbSet<Cempohuallapohualli> dbSet)
        => await dbSet.AddRangeAsync(_months);
}