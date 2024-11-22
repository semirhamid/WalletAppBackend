namespace WalletApp.Domain.Exceptions
{
  public class EntityNotFoundException : Exception
  {
    public EntityNotFoundException(string entityName, object key)
        : base($"Entity \"{entityName}\" ({key}) was not found.")
    {
    }
  }
}
