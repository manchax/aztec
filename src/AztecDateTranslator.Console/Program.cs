using AztecDateTranslator.Shared;
using AztecDateTranslator.Shared.Services;

File.Delete("C:\\Users\\manchax\\AppData\\Local\\aztec.db");
var context = new AztecContext();
context.Database.EnsureCreated();

var finder = new DaySignFinder(context);

// Convert(new DateTime(1960, 1, 19));
// Convert(new DateTime(1983, 5, 19));

for (int i = 0; i < 20; i++)
{
    Convert(DateTime.Now.Date.AddDays(i));
}

context.Dispose();
Console.ReadKey();

void Convert(DateTime date)
{
    var sign = finder.GetTzolkinDate(date);
    Console.WriteLine("{4}: {0,3} - {1}\t\t{2}\t{3}", sign.HeavenNumber,
        sign.DaySign!.Nahuatl, sign.DaySign.Mayan, sign.DaySign.Spanish,
        date.Date.ToLongDateString());
}
