namespace WalletApp.Domain.Entities;

public class Points
{
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public WalletUser User { get; set; } 

    public int PointsValue { get; set; }  
    public DateTime Date { get; set; }  
}