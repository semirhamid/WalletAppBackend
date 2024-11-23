using WalletApp.Application.DTOs.Common;

namespace WalletApp.Application.DTOs.WalletDto;

public abstract class WalletResponseDto : BaseDTO
{
    public Guid UserId { get; set; }
    public decimal CurrentBalance { get; set; }
    public decimal TotalPoints { get; set; }
}

public class CreateWalletDto
{
    public Guid UserId { get; set; }
    public decimal CurrentBalance { get; set; }
    public decimal TotalPoints { get; set; }
}

public class UpdateWalletDto : WalletResponseDto
{
    
}