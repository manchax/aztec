using AztecDateTranslator.Shared;
using AztecDateTranslator.Shared.Services;

//var start = new DateTime(1999, 1, 5);
//var dates = new List<DateTime>();
//dates.Add(start);
//for (var i = 1; i <= 13; i++) { 
//    dates.Add(start.AddDays(i * 360));
//}
//var month = now.Month;

// File.Delete("C:\\Users\\manchax\\AppData\\Local\\aztec.db");
using var context = new AztecContext();
// context.Database.EnsureCreated();
var finder = new DateTranslator(context);
var now = DateTime.Now.Date;
var date = now;
    /*new DateTime(now.Year, now.Month, 1);
    new DateTime(1983, 5, 19);
    /*new DateTime(2025, 8, 1)*/;

while (await KeepGoing(date))
{
    date = date.AddMonths(1);
}

async Task<bool> KeepGoing(DateTime date)
{
    PrintHeader();
    var days = DateTime.DaysInMonth(date.Year, date.Month);
    for (int i = 0; i < days; i++)
    {
        await Convert(date);
        date = date.AddDays(1);
    }

    Console.WriteLine("Press Q to exit or any other key to continue...");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.Q)
    {
        context.Dispose();
        return false;
    }

    Console.Clear();
    return true;
}

static void PrintHeader()
{
    Console.WriteLine("{0, -30} | {1, -18} | {2, -10} | {3, -10} | {4} | {5} | {6,-20}",
        "               Date", "Tonalpohualli", "Maya", "Nahual",
        "Tzolkin #", // 4
        "Special?", "Xiuhpohualli");
    Console.WriteLine($"{new string([.. Enumerable.Repeat('-', 125)])}");
}

async Task Convert(DateTime date)
{
    var t1 = Task.Run(() => finder.Tonalpohualli(date));
    var t2 = Task.Run(() => finder.Xiuhpohualli(date));

    await Task.WhenAll(t1, t2);
    var sign = t1.Result;
    var solar = t2.Result;

    Console.WriteLine(
        "{4, 30} | {0,3} {1, -14} | {2, -10} | {3, -10} | {6, 9} | {5, 8} | {8,3} {7,-16}",
        sign.HeavenNumber, // 0
        sign.DaySign!.Nahuatl, //1
        // sign.DaySign.Mayan,  // 2
        sign.DaySign.Mayan,
        sign.DaySign.Spanish,     // 3
        date.Date.ToLongDateString(), // 4
        sign.IsSpecial ? 'Y' : 'N',         // 5
        sign.TzolkinPosition,                       // 6,
        solar.mes.Name + $" ({solar.mes.Number})", // 7
        solar.dia); // 8
}