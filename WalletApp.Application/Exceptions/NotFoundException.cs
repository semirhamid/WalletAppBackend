namespace WalletApp.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key)
        : base($"{name} with key ({key}) was not found.")
    {
    }
}