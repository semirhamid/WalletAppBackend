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
    

    public bool CanProcessTransaction(Wallet wallet, Transaction transaction)
    {
        decimal maxLimit = 1500;
        var transactionAmount = transaction.Amount;
        

        if (transaction.Type == TransactionType.Credit && wallet.CurrentBalance - transactionAmount < 0)
        {
            throw new InvalidOperationException("Insufficient funds for this transaction.");
        }

        if (transaction.Type == TransactionType.Payment && wallet.CurrentBalance + transactionAmount > maxLimit)
        {
            throw new InvalidOperationException("Transaction exceeds the maximum card limit.");
        }

        wallet.CurrentBalance += (transaction.Type == TransactionType.Payment ? transactionAmount : -transactionAmount);
        return true;
    }

}