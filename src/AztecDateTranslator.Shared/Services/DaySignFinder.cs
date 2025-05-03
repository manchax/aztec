using AztecDateTranslator.Shared.Entities;
using AztecDateTranslator.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AztecDateTranslator.Shared.Services;

public class DaySignFinder : IDaySignTranslator
{
    //private readonly IDbContextFactory<AztecContext> _dbContextFactory;

    //public DaySignFinder(IDbContextFactory<AztecContext> dbContextFactory) 
    //{
    //    _dbContextFactory = dbContextFactory;
    //}

    private AztecContext _context;
    public DaySignFinder(AztecContext dbContext)
    {
        _context = dbContext;
    }

    public Tonalpohualli GetTzolkinDate(DateTime date)
    {
        decimal dayCount = CountDaysByYear(date)
            + CountDaysByMonth(date)
            + date.Day;

        dayCount /= 260m;
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

    private Tonalpohualli FindDaySign(int position, bool isSpecial)
    {
        int veintena = 1;
        int trecena = 1;
        for (int i = 1; i < position; i++)
        {
#if DEBUG
            Debug.WriteLine("{0} - {1}", trecena, veintena);
#endif
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
        sign = _context.DaySigns
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

    private int CountDaysByMonth(DateTime date)
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
        var startDate = new DateTime(1900, 1, 1);
        int year = date.Year;
        int diffYears = year - startDate.Year;
        int result = 0;
        for (int i = 0; i < diffYears; i++)
        {
            result += IsDayAdded(startDate.Year + i) ? 366 : 365;
        }

        return result;

        bool IsDayAdded(int year)
        {
            return DateTime.IsLeapYear(year + 1);
        }
    }
}