using WalletApp.Domain.Entities;

namespace WalletApp.Application.Contracts.Persistence;

public interface IWalletRepository : IGenericRepository<Wallet>
{
    Task<Wallet> GetByWalletUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task UpdateUserPointsAsync(Guid userId, int points, CancellationToken cancellationToken);
    
}