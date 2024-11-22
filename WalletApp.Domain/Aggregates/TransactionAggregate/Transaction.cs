using WalletApp.Domain.Common;

namespace WalletApp.Domain.Aggregates.TransactionAggregate
{
  public class Transaction : BaseEntity, ITransactionRoot
  {
    public string Name { get; private set; }
    public Money Amount { get; private set; }
    public DateTime Date { get; private set; }
    public TransactionType Type { get; private set; }

    public Transaction(string name, Money amount, DateTime date, TransactionType type)
    {
      Name = name;
      Amount = amount;
      Date = date;
      Type = type;
    }
  }
}
