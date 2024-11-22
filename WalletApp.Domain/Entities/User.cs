using WalletApp.Domain.Common;

namespace WalletApp.Domain.Entities
{
  public class User : BaseEntity
  {
    public string Name { get; private set; }
    public string Email { get; private set; }

    public User(string name, string email)
    {
      Name = name;
      Email = email;
    }
  }
}
