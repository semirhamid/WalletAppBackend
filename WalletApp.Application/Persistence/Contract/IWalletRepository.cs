using WalletApp.Domain.Entities;

namespace WalletApp.Application.Persistence.Contract;

public interface IWalletRepository : IGenericInterface<Wallet>
{
    Task<Wallet> GetByWalletUserIdAsync(Guid userId, CancellationToken cancellationToken);
    
}