using WalletApp.Domain.Common;

namespace WalletApp.Domain.Entities;

public class Point : BaseEntity
{
    public Guid UserId { get; set; }
    public WalletUser User { get; set; } 

    public decimal PointValue { get; set; }  
    public DateTime Date { get; set; }  
}