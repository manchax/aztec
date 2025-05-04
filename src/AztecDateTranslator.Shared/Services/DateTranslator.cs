using AztecDateTranslator.Shared.Entities;
using AztecDateTranslator.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;

namespace AztecDateTranslator.Shared.Services;

public class DateTranslator : IDateTranslator
{
    //private readonly IDbContextFactory<AztecContext> _dbContextFactory;

    //public DaySignFinder(IDbContextFactory<AztecContext> dbContextFactory) 
    //{
    //    _dbContextFactory = dbContextFactory;
    //}

    private DateTime _zero = new(1900, 1, 1);

    private AztecContext _context;

    private IEnumerable<DaySign> _daySigns;
    private IEnumerable<Cempohuallapohualli> _months;

    public DateTranslator(AztecContext dbContext)
    {
        _context = dbContext;
        _daySigns = _context.DaySigns.AsNoTracking().ToList();
        _months = _context.Cempohuallapohuallis.AsNoTracking().ToList();
    }

    public (Cempohuallapohualli mes, int dia)
        Xiuhpohualli(DateTime date)
    {
        var dayCount = GetDayCount(date, tzolkin: false);
        var tuns = dayCount / 360m;
        Debug.WriteLine($"Tun count (solar) is: {tuns}");
        var fraction = tuns - decimal.Truncate(tuns);
        var position = fraction switch
        {
            0 => 360, // last position
            _ => (int)Math.Round(fraction * 360m)
        };
        Debug.WriteLine($"Position: {position}");
        // var cycleStart = FindNearestCycleStart(date);

        var mes = position / 20; // 20 days each month
        // fraction = mes - decimal.Truncate(mes);
        //var iMes = Convert.ToInt32(
        //    Math.Round(mes));
        //if (iMes == 0)
        //{
        //    iMes = 18;
        //}
        if (mes == 0)
        {
            //Debugger.Break();
            mes = 18;
        }

        var month = _months.Where(m => m.Number == mes)
            .First();
        var day = position % 20;

        return (month, day);
    }

    private DateTime FindNearestCycleStart(DateTime date)
    {
        return DateTime.Now;
    }

    public Tonalpohualli Tonalpohualli(DateTime date)
    {
        var dayCount = GetDayCount(date) / 260m;
        var fraction = dayCount - decimal.Truncate(dayCount);
        var position = fraction switch
        {
            0 => 260,
            _ => Convert.ToInt32(fraction * 260m)
        };

        int[] specialDays = [
            1, 20,
            22, 39,
            43, 50, 51, 58,
            64, 69, 72, 77,
            85, 88, 93, 96,
            106, 107, 108, 109, 110, 111, 112, 113, 114, 115];

        specialDays = [.. specialDays,
            146, 147, 148, 149, 150, 151, 152, 153, 154, 155,
            165, 168, 173, 176,
            184, 189, 192, 197,
            203, 210, 211, 218,
            222, 239,
            241, 260];

        if (position < 1 || position > 260)
        {
            throw new ArithmeticException("Invalid result");
        }
        return FindDaySign(position, specialDays.Contains(position));
    }

    /// <summary>
    /// Gets the count of the days from Jan 1st, 1900.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="tzolkin"></param>
    /// <returns></returns>
    private int GetDayCount(DateTime date, bool tzolkin = true)
        => CountDaysByYear(date) + (tzolkin
        ? TzolkinDayCountByMonth(date)
        : TunDayCountByMonth(date)) + date.Day;

    private Tonalpohualli FindDaySign(int position, bool isSpecial)
    {
        int veintena = 1;
        int trecena = 1;
        for (int i = 1; i < position; i++)
        {
            //#if DEBUG
            //            Debug.WriteLine("{0} - {1}", trecena, veintena);
            //#endif
            trecena = trecena switch
            {
                13 => 1,
                _ => trecena + 1,
            };
            veintena = veintena switch
            {
                20 => 1,
                _ => veintena + 1,
            };
        }

        DaySign sign;
        //using (var dbContext = _dbContextFactory.CreateDbContext())
        //{
        sign = _daySigns
            .Where(d => d.DayNumber == veintena)
            .First();
        //}

        return new Tonalpohualli
        {
            HeavenNumber = (byte)trecena,
            DaySign = sign,
            IsSpecial = isSpecial,
            TzolkinPosition = position,
        };
    }

    /// <summary>
    /// Count of the days from Jan 1st, 1900.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private int TunDayCountByMonth(DateTime date)
    {
        var isLeapYear = DateTime.IsLeapYear(date.Year);
        return date.Month switch
        {
            1 => isLeapYear ? 196 : 197,
            2 => isLeapYear ? 227 : 228,
            3 => 256,
            4 => 287,
            5 => 317,
            6 => 348,
            7 => 378,
            8 => 409,
            9 => 440,
            10 => 470,
            11 => 501,
            12 => 531,
            _ => throw new Exception(),
        };
    }

    private int TzolkinDayCountByMonth(DateTime date)
    {
        var isLeapYear = DateTime.IsLeapYear(date.Year);
        return date.Month switch
        {
            1 => isLeapYear ? 236 : 237,
            2 => isLeapYear ? 267 : 268,
            3 => 296,
            4 => 327,
            5 => 357,
            6 => 388,
            7 => 418,
            8 => 449,
            9 => 480,
            10 => 510,
            11 => 541,
            12 => 571,
            _ => throw new Exception(),
        };
    }

    private int CountDaysByYear(DateTime date)
    {
        int diffYears = date.Year - _zero.Year;
        int result = 0;
        for (int i = 0; i < diffYears; i++)
        {
            result += IsDayAdded(_zero.Year + i) ? 366 : 365;
        }
        return result;
        bool IsDayAdded(int year) => DateTime.IsLeapYear(year + 1);
    }
}