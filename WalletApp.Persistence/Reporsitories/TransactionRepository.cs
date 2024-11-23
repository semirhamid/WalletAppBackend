using Microsoft.EntityFrameworkCore;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Infrastructure.Persistence.Reporsitories;

public class TransactionRepository: GenericRepository<Transaction>, ITransactionRepository
{
    private readonly WalletAppDbContext _context;

    public TransactionRepository(WalletAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetRecentTransactions(Guid userId, CancellationToken cancellationToken)
    {
        return  _context.Transactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.Date);
    }

    public async Task<Transaction?> GetTransactionById(Guid transactionId, CancellationToken cancellationToken)
    {
        var transaction = await _context.Transactions
            .FirstOrDefaultAsync(t => t.Id == transactionId);

        return transaction;
    }
}