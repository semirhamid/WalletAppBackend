using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Infrastructure.Persistence.Reporsitories;

public class WalletUserRepository : GenericRepository<WalletUser>, IWalletUserRepository
{
    public WalletUserRepository(WalletAppDbContext context) : base(context)
    {
    }
}