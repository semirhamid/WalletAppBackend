namespace WalletApp.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
  Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
  Task<T> GetByIdAsync(Guid id, CancellationToken? cancellationToken);
  Task<T> AddAsync(T entity, CancellationToken cancellationToken);
  Task<T> UpdateAsync(T entity, CancellationToken? cancellationToken);
  Task<T> DeleteAsync(Guid id, CancellationToken cancellationToken);
}