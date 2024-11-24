using WalletApp.Domain.Common;

namespace WalletApp.Domain.Entities
{
  public class Transaction : BaseEntity
  {
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public TransationStatus Status { get; set; }
    public Guid UserId { get; set; }
    public WalletUser WalletUser { get; set; }
  }
}