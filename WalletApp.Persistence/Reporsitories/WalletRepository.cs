using Microsoft.EntityFrameworkCore;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Domain.Entities;

namespace WalletApp.Infrastructure.Persistence.Reporsitories;

public class WalletRepository: GenericRepository<Wallet>, IWalletRepository
{
    private readonly WalletAppDbContext _context;

    public WalletRepository(WalletAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Wallet> GetByWalletUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId, cancellationToken);
    }

    public async Task UpdateUserPointsAsync(Guid userId, int points, CancellationToken cancellationToken)
    {
        var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId, cancellationToken);
        if (wallet != null)
        {
            wallet.TotalPoints += points;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}