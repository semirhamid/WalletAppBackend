using WalletApp.Application.DTOs.Common;

namespace WalletApp.Application.DTOs.PointDto;

public class UpdatePointDto: PointResponseDto
{
}
public class PointResponseDto: BaseDTO
{
    public Guid UserId { get; set; }
    public decimal PointValue { get; set; }
    public DateTime Date { get; set; }
}

public class CreatePointDto
{
    public Guid UserId { get; set; }
    public decimal PointValue { get; set; }
    public DateTime Date { get; set; }
}