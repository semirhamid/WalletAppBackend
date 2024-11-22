namespace WalletApp.Application.DTOs.Wallet;

public class WalletDto
{
    public Guid UserId { get; set; }
    public decimal CurrentBalance { get; set; }
    public int TotalPoints { get; set; }
}