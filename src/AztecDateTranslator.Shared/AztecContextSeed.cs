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
            Maya = "Imix",
            Spanish = "Cocodrilo",
            English = "Alligator",
            AztecDeity = "Tonacatecuhtli",
            Description = "dios de la procreación"
        },
        new DaySign {
            DayNumber = 2,
            Nagual = Naguales.Wind,
            Nahuatl = "Ehécatl",
            Maya = "Ik",
            Spanish = "Viento",
            English = "Wind",
            AztecDeity = "Ehécatl",
            Description = "dios del viento"
        },
        new DaySign {
            DayNumber = 3,
            Nagual = Naguales.House,
            Nahuatl = "Calli",
            Maya = "Akbal",
            Spanish = "Casa",
            English = "House",
            AztecDeity = "Tepeyollotl",
            Description = "corazón de la montaña"
        },
        new DaySign {
            DayNumber = 4,
            Nagual = Naguales.Lizard,
            Nahuatl = "Cuetzpallin",
            Maya = "Kan",
            Spanish = "Lagartija",
            English = "Lizard",
            AztecDeity = "Huehuecoyotl",
            Description = "dios de la danza"
        },
        new DaySign {
            DayNumber = 5,
            Nagual = Naguales.Serpent,
            Nahuatl = "Cóatl",
            Maya = "Chicchan",
            Spanish = "Serpiente",
            English = "Serpent",
            AztecDeity = "Chalchiuhtlicue",
            Description = "diosa del agua"
        },
        new DaySign {
            DayNumber = 6,
            Nagual = Naguales.Death,
            Nahuatl = "Miquiztli",
            Maya = "Cimi",
            Spanish = "Muerte",
            English = "Death",
            AztecDeity = "Tecciztécatl",
            Description = "diosa de la luna"
        },
        new DaySign {
            DayNumber = 7,
            Nagual = Naguales.Deer,
            Nahuatl = "Mazatl",
            Maya = "Manik",
            Spanish = "Venado",
            English = "Deer",
            AztecDeity = "Tláloc",
            Description = "dios de la lluvia y de la guerra"
        },
        new DaySign {
            DayNumber = 8,
            Nagual = Naguales.Rabbit,
            Nahuatl = "Tochtli",
            Maya = "Lamat",
            Spanish = "Conejo",
            English = "Rabbit",
            AztecDeity = "Mayahuel",
            Description = "diosa del pulque"
        },
        new DaySign {
            DayNumber = 9,
            Nagual = Naguales.Water,
            Nahuatl = "Atl",
            Maya = "Muluc",
            Spanish = "Agua",
            English = "Water",
            AztecDeity = "Xiuhtecuhtli",
            Description = "dios del fuego y el tiempo"
        },
        new DaySign {
            DayNumber = 10,
            Nagual = Naguales.Dog,
            Nahuatl = "Itzcuintli",
            Maya = "Oc",
            Spanish = "Perro",
            English = "Dog",
            AztecDeity = "Mictlantecuhtli",
            Description = "dios de la muerte"
        },
        new DaySign {
            DayNumber = 11,
            Nagual = Naguales.Monkey,
            Nahuatl = "Ozomatli",
            Maya = "Chuen",
            Spanish = "Mono",
            English = "Monkey",
            AztecDeity = "Xochipilli",
            Description = "dios de las flores"
        },
        new DaySign {
            DayNumber = 12,
            Nagual = Naguales.Grass,
            Nahuatl = "Malinali",
            Maya = "Eb",
            Spanish = "Hierba",
            English = "Grass",
            AztecDeity = "Patécatl",
            Description = "dios de la medicina"
        },
        new DaySign {
            DayNumber = 13,
            Nagual = Naguales.Reed,
            Nahuatl = "Ácatl",
            Maya = "Ben",
            Spanish = "Carrizo",
            English = "Reed",
            AztecDeity = "Tezcatlipoca",
            Description = "dios de la obscuridad"
        },
        new DaySign {
            DayNumber = 14,
            Nagual = Naguales.Ocelot,
            Nahuatl = "Ocelotl",
            Maya = "Ix",
            Spanish = "Ocelote",
            English = "Ocelot",
            AztecDeity = "Tlacolteotl",
            Description = "diosa del amor y del nacimiento"
        },
        new DaySign {
            DayNumber = 15,
            Nagual = Naguales.Eagle,
            Nahuatl = "Cuauhtli",
            Maya = "Men",
            Spanish = "Águila",
            English = "Eagle",
            AztecDeity = "Tezcatlipoca-Xipe Totec",
            Description = "dios de la obscuridad, dios desollado"
        },
        new DaySign {
            DayNumber = 16,
            Nagual = Naguales.Vulture,
            Nahuatl = "Cozcacuauhtli",
            Maya = "Cib",
            Spanish = "Buitre",
            English = "Vulture",
            AztecDeity = "Itzpapalotl",
            Description = "mariposa de obsidiana"
        },
        new DaySign {
            DayNumber = 17,
            Nagual = Naguales.Movement,
            Nahuatl = "Ollin",
            Maya = "Caban",
            Spanish = "Movimiento",
            English = "Movement",
            AztecDeity = "Xolotl-Nanahuatzin",
            Description = "mounstro con cabeza de perro, sol"
        },
        new DaySign {
            DayNumber = 18,
            Nagual = Naguales.Knife,
            Nahuatl = "Tecpatl",
            Maya = "Etznab",
            Spanish = "Cuchillo",
            English = "Knife",
            AztecDeity = "Chalchiuhtotolin",
            Description = "dios guajolote y una variante de Tezcatlipoca como pájaro"
        },
        new DaySign {
            DayNumber = 19,
            Nagual = Naguales.Rain,
            Nahuatl = "Quiahuitl",
            Maya = "Cauac",
            Spanish = "Lluvia",
            English = "Rain",
            AztecDeity = "Tonatiuh",
            Description = "dios del sol y de los guerreros"
        },
        new DaySign {
            DayNumber = 20,
            Nagual = Naguales.Flower,
            Nahuatl = "Xóchitl",
            Maya = "Ahau",
            Spanish = "Flor",
            English = "Flower",
            AztecDeity = "Xochiquetzal",
            Description = "diosa de las flores"
        }
    ];

    private readonly IEnumerable<Cempohuallapohualli> _months = [
        new Cempohuallapohualli {
            Number = 1,
            Name = "Cuahuitlehua", Maya = "Pop",
            Deity = "Tláloc",
            Description = "cesan las aguas o elevación de los árboles",
        },
        new Cempohuallapohualli {
            Number = 2,
            Name = "Cuahuitlehua", Maya = "Wo'",
            Deity = "Xipe Tótec",
            Description = "desolladura de hombres",
        },
        new Cempohuallapohualli {
            Number = 3,
            Name = "Tozoztontli", Maya = "Sip",
            Deity = "Coatlicue",
            Description = "pequeña vigilia",
        },
        new Cempohuallapohualli {
            Number = 4,
            Name = "Huey Tozoztli", Maya = "Sotz",
            Deity = "Cintéotl-Chicomecóatl",
            Description = "gran vigilia",
        },
        new Cempohuallapohualli {
            Number = 5,
            Name = "Tóxcatl", Maya = "Sek",
            Deity = "Tezcatlipoca-Huitzilopochtli",
            Description = "sequedad o sequía",
        },
        new Cempohuallapohualli {
            Number = 6,
            Name = "Etzalcualiztli", Maya = "Xul",
            Deity = "Tláloc",
            Description = "se come eztalli",
        },
        new Cempohuallapohualli {
            Number = 7,
            Name = "Tecuilhuitontli", Maya = "Yaxkin",
            Deity = "Huixtocíhuatl",
            Description = "pequeña fiesta de los señores",
        },
        new Cempohuallapohualli {
            Number = 8,
            Name = "Huey Tecuilhuitl", Maya = "Mol",
            Deity = "Xilonen-Xochipilli",
            Description = "gran fiesta de los señores",
        },
        new Cempohuallapohualli {
            Number = 9,
            Name = "Tlaxochimaco", Maya = "Ch'en",
            Deity = "Huitzilopochtli-Mictlantecuhtli",
            Description = "ofrenda de las flores o pequeña fiesta de los muertos",
        },
        new Cempohuallapohualli {
            Number = 10,
            Name = "Xocotlhuetzi", Maya = "Sak",
            Deity = "Xiuhtecuhtli-Yacatecuhtl-Mictlantecuhtli",
            Description = "el fruto cae o gran fiesta de los muertos",
        },
        new Cempohuallapohualli {
            Number = 11,
            Name = "Ochpaniztli", Maya = "Keh",
            Deity = "Atlatonan-Chicomecóatl-Toci",
            Description = "barrimiento",
        },
        new Cempohuallapohualli {
            Number = 12,
            Name = "Teotleco", Maya = "Mac",
            Deity = "",
            Description = "llegada de los dioses",
        },
        new Cempohuallapohualli {
            Number = 13,
            Name = "Tepeilhuitl", Maya = "",
            Deity = "",
            Description = "la fiesta de las montañas",
        },
        new Cempohuallapohualli {
            Number = 14,
            Name = "Quecholli", Maya = "Kankin",
            Deity = "Mixcóatl",
            Description = "lanza de guerra o precioso penacho",
        },
        new Cempohuallapohualli {
            Number = 15,
            Name = "Panquetzaliztli", Maya = "Muwan",
            Deity = "Huitzilopochtli",
            Description = "levantamiento de banderas",
        },
        new Cempohuallapohualli {
            Number = 16,
            Name = "Atemoztli", Maya = "Pax",
            Deity = "Tláloc",
            Description = "bajan las aguas",
        },
        new Cempohuallapohualli {
            Number = 17,
            Name = "Títitl", Maya = "Kayab",
            Deity = "Ilamatecuhtli-Mixcóatl",
            Description = "arrugado",
        },
        new Cempohuallapohualli {
            Number = 18,
            Name = "Izcalli", Maya = "Cumkú",
            Deity = "Xiuhtecutli",
            Description = "resurrección o renovación",
        },
        new Cempohuallapohualli {
            Number = 19,
            Name = "Nemontemi", Maya = "Wayeb",
            Deity = "",
            Description = "5 días funestos",
        }
    ];

    private void AddDaySigns(DbSet<DaySign> dbSet)
        => dbSet.AddRange(_signs);

    private async Task AddDaySignsAsync(DbSet<DaySign> dbSet)
        => await dbSet.AddRangeAsync(_signs);

    private void AddCempohuallapohuallis(DbSet<Cempohuallapohualli> dbSet)
        => dbSet.AddRange(_months);

    private async Task AddCempohuallapohuallisAsync(DbSet<Cempohuallapohualli> dbSet)
        => await dbSet.AddRangeAsync(_months);
}