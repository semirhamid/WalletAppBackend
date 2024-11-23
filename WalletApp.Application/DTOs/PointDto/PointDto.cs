using WalletApp.Application.DTOs.Common;

namespace WalletApp.Application.DTOs.PointDto;

public class PointDto: BaseDTO
{
    public Guid UserId { get; set; }
    public int PointValue { get; set; }
    public DateTime Date { get; set; }
}