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
            English = "Alligator"
        },
        new DaySign {
            DayNumber = 2,
            Nagual = Naguales.Wind,
            Nahuatl = "Ehécatl",
            Mayan = "Ik",
            Spanish = "Viento",
            English = "Wind"
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

    private readonly IEnumerable<Cempohuallapohualli> _months = [
        new Cempohuallapohualli {
            Number = 1,
            Name = "Cuahuitlehua",
            Description = "",
            Deity = "Tláloc"
        },
        new Cempohuallapohualli {
            Number = 2,
            Name = "Cuahuitlehua",
            Description = "",
            Deity = "Xipe Tótec"
        },
        new Cempohuallapohualli {
            Number = 3,
            Name = "Tozoztontli",
            Description = "",
            Deity = "Coatlicue"
        },
        new Cempohuallapohualli {
            Number = 4,
            Name = "Huey Tozoztli",
            Description = "",
            Deity = "Cintéotl-Chicomecóatl"
        },
        new Cempohuallapohualli {
            Number = 5,
            Name = "Tóxcatl",
            Description = "",
            Deity = "Tezcatlipoca-Huitzilopochtli"
        },
        new Cempohuallapohualli {
            Number = 6,
            Name = "Etzalcualiztli",
            Description = "",
            Deity = "Tláloc"
        },
        new Cempohuallapohualli {
            Number = 7,
            Name = "Tecuilhuitontli",
            Description = "",
            Deity = "Huixtocíhuatl"
        },
        new Cempohuallapohualli {
            Number = 8,
            Name = "Huey Tecuilhuitl",
            Description = "",
            Deity = "Xilonen-Xochipilli"
        },
        new Cempohuallapohualli {
            Number = 9,
            Name = "Tlaxochimaco",
            Description = "",
            Deity = "Huitzilopochtli-Mictlantecuhtli"
        },
        new Cempohuallapohualli {
            Number = 10,
            Name = "Xocotlhuetzi",
            Description = "",
            Deity = "Xiuhtecuhtli-Yacatecuhtl-Mictlantecuhtli"
        },
        new Cempohuallapohualli {
            Number = 11,
            Name = "Ochpaniztli",
            Description = "Atlatonan-Chicomecóatl-Toci",
            Deity = ""
        },
        new Cempohuallapohualli {
            Number = 12,
            Name = "Teotleco",
            Description = "",
            Deity = ""
        },
        new Cempohuallapohualli {
            Number = 13,
            Name = "Tepeilhuitl",
            Description = "",
            Deity = ""
        },
        new Cempohuallapohualli {
            Number = 14,
            Name = "Quecholli",
            Description = "",
            Deity = "Mixcóatl"
        },
        new Cempohuallapohualli {
            Number = 15,
            Name = "Panquetzaliztli",
            Description = "",
            Deity = "Huitzilopochtli"
        },
        new Cempohuallapohualli {
            Number = 16,
            Name = "Atemoztli",
            Description = "",
            Deity = "Tláloc"
        },
        new Cempohuallapohualli {
            Number = 17,
            Name = "Títitl",
            Description = "",
            Deity = "Ilamatecuhtli-Mixcóatl"
        },
        new Cempohuallapohualli {
            Number = 18,
            Name = "Izcalli",
            Description = "",
            Deity = "Xiuhtecutli"
        },
        new Cempohuallapohualli {
            Number = 19,
            Name = "Nemontemi",
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