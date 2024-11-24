using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Queries;

public class GetWalletByWalletUserIdQuery : IRequest<WalletResponseDto>
{
    public Guid WalletUserId { get; set; }
}