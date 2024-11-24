using WalletApp.Application.Contracts.Persistence;
using WalletApp.Domain.Entities;

namespace WalletApp.Infrastructure.Persistence.Reporsitories;

public class WalletUserRepository : GenericRepository<WalletUser>, IWalletUserRepository
{
    public WalletUserRepository(WalletAppDbContext context) : base(context)
    {
    }
}