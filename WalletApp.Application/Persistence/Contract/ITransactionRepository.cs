using WalletApp.Domain.Entities;

namespace WalletApp.Persistence.Contract;

public interface ITransactionRepository : IGenericInterface<Transaction>
{
    Task<IEnumerable<Transaction>> GetRecentTransactions(Guid userId);
    Task<Transaction?> GetTransactionById(Guid transactionId);
}