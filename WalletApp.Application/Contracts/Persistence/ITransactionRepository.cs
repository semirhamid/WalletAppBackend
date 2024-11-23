using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Contracts.Persistence;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetRecentTransactions(Guid userId, CancellationToken cancellationToken);
    Task<Transaction?> GetTransactionById(Guid transactionId,CancellationToken cancellationToken);
}