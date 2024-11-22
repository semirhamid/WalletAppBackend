using WalletApp.Domain.Common;

namespace WalletApp.Domain.Entities;

public class Wallet : BaseEntity
{
    public decimal CurrentBalance { get; private set; }
    public int TotalPoints { get; private set; }
    public Guid UserId { get; set; }
    public WalletUser User { get; set; }
    
}