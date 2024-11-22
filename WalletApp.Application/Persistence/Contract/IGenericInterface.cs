namespace WalletApp.Persistence.Contract;

public interface IGenericInterface<T> where T : class
{
  Task<IReadOnlyList<T>> GetAllAsync();
  Task<T> GetByIdAsync(int id);
  Task<T> AddAsync(T entity);
  Task<T> UpdateAsync(T entity);
  Task<T> DeleteAsync(int id);
}