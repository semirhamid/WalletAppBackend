using WalletApp.Domain.Entities;

namespace WalletApp.Application.Services;

public interface IPointService
{
    int CalculatePoints(IEnumerable<Transaction> transactions, DateTime date);
}