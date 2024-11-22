using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Queries;

public class GetWalletByWalletUserIdQuery : IRequest<WalletDto>
{
    public Guid WalletUserId { get; set; }
}