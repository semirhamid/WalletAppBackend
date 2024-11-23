using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Persistence.Contract;

public interface ITransactionRepository : IGenericInterface<Transaction>
{
    Task<IEnumerable<TransactionResponseDto>> GetRecentTransactions(Guid userId, CancellationToken cancellationToken);
    Task<TransactionResponseDto?> GetTransactionById(Guid transactionId,CancellationToken cancellationToken);
}