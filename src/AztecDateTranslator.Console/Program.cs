using AztecDateTranslator.Shared;
using AztecDateTranslator.Shared.Services;

File.Delete("C:\\Users\\manchax\\AppData\\Local\\aztec.db");
var context = new AztecContext();
context.Database.EnsureCreated();

var finder = new DaySignFinder(context);

// Convert(new DateTime(1960, 1, 19));
// Convert(new DateTime(1983, 5, 19));
var now = DateTime.Now.Date;
var days = DateTime.DaysInMonth(now.Year, now.Month);
var date = new DateTime(now.Year, now.Month, 1);
for (int i = 0; i < days; i++)
{
    Convert(date);
    date = date.AddDays(1);
}

context.Dispose();
Console.ReadKey();

void Convert(DateTime date)
{
    var sign = finder.GetTzolkinDate(date);
    Console.WriteLine("{4, 25} | {0,3} - {1, -15} | {2, -10} | {3, -10} | {6,3} | {5}",
        sign.HeavenNumber,
        sign.DaySign!.Nahuatl, sign.DaySign.Mayan, sign.DaySign.Spanish,
        date.Date.ToLongDateString(), sign.IsSpecial ? 'Y' : 'N',
        sign.TzolkinPosition);
}
