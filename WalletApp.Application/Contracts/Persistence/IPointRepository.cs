using WalletApp.Application.DTOs.PointDto;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Contracts.Persistence;

public interface IPointRepository: IGenericRepository<Point>
{
    Task<IEnumerable<Point>> GetPointsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}