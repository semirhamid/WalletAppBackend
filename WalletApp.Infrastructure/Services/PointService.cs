using WalletApp.Application.Services;
using WalletApp.Domain.Entities;

namespace WalletApp.Infrastructure.Services;

public class PointService : IPointService
{
    public int CalculatePoints(IEnumerable<Transaction> transactions, DateTime date)
    {
        int points = 0;

        var seasonStart = GetSeasonStart(date);
        var dayInSeason = (date - seasonStart).Days + 1;

        if (dayInSeason == 1)
        {
            points += 2;
        }
        else if (dayInSeason == 2)
        {
            points += 3;
        }
        else
        {
            var previousDayPoints = GetPointsFromDate(transactions, date.AddDays(-1));
            var twoDaysAgoPoints = GetPointsFromDate(transactions, date.AddDays(-2));

            points += previousDayPoints;
            points += (int)(twoDaysAgoPoints * 0.6);
        }

        return points;
    }

    private DateTime GetSeasonStart(DateTime date)
    {
        return date.Month switch
        {
            12 or 1 or 2 => new DateTime(date.Year, 12, 1), // Winter
            3 or 4 or 5 => new DateTime(date.Year, 3, 1),  // Spring
            6 or 7 or 8 => new DateTime(date.Year, 6, 1),  // Summer
            9 or 10 or 11 => new DateTime(date.Year, 9, 1), // Autumn
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private int GetPointsFromDate(IEnumerable<Transaction> transactions, DateTime date)
    {
        return transactions
            .Where(t => t.Date.Date == date.Date)
            .Sum(t => t.Amount > 0 ? 1 : 0);
    }
}
