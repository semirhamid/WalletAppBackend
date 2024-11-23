using WalletApp.Application.DTOs.PointDto;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Persistence.Contract;

public interface IPointRepository: IGenericInterface<Point>
{
    Task<IEnumerable<PointResponseDto>> GetPointsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}