namespace WalletApp.Application.DTOs.WalletDto;

public class WalletDto
{
    public Guid UserId { get; set; }
    public decimal CurrentBalance { get; set; }
    public float TotalPoints { get; set; }
}