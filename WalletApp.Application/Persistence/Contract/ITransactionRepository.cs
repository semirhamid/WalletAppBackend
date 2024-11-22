using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Persistence.Contract;

public interface ITransactionRepository : IGenericInterface<Transaction>
{
    Task<IEnumerable<TransactionDTO>> GetRecentTransactions(Guid userId, CancellationToken cancellationToken);
    Task<TransactionDTO?> GetTransactionById(Guid transactionId,CancellationToken cancellationToken);
}