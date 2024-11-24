using Microsoft.EntityFrameworkCore;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Contracts.Persistence;
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

    public async Task<decimal> GetAmountLeftForMonth(Guid userId, decimal monthlyTarget, CancellationToken cancellationToken)
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;

        // Sum all successful payments for the current month
        var totalPaid = await _context.Transactions
            .Where(t => t.UserId == userId 
                        && t.Type == TransactionType.Payment 
                        && t.Status == TransationStatus.Authorized 
                        && t.Date.Month == currentMonth 
                        && t.Date.Year == currentYear)
            .SumAsync(t => t.Amount, cancellationToken);

        // Calculate the amount left
        return Math.Max(monthlyTarget - totalPaid, 0); 
    }

    public async Task<(string message, decimal amountLeft)> GetPaymentStatus(Guid userId, decimal monthlyTarget, CancellationToken cancellationToken)
    {
        var amountLeft = await this.GetAmountLeftForMonth(userId, monthlyTarget, cancellationToken);

        if (amountLeft == 0)
        {
            var currentMonth = DateTime.Now.ToString("MMMM");
            return ($"You've paid your {currentMonth}", amountLeft);
        }

        return ($"You still need to pay ${amountLeft} this month.", amountLeft);
    }
}