using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Domain.Entities;

namespace WalletApp.Infrastructure.Persistence.Reporsitories;

public class PointRepository: GenericRepository<Point>, IPointRepository
{
    private readonly WalletAppDbContext _context;

    public PointRepository(WalletAppDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<IEnumerable<Point>> GetPointsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}