using WalletApp.Domain.Entities;

namespace WalletApp.Application.Persistence.Contract;

public interface IWalletRepository : IGenericRepository<Wallet>
{
    Task<Wallet> GetByWalletUserIdAsync(Guid userId, CancellationToken cancellationToken);
    
}