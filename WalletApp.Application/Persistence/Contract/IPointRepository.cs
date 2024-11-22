using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Persistence.Contract;

public interface IPointRepository: IGenericInterface<PointDto>
{
    Task<IEnumerable<PointDto>> GetPointsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}