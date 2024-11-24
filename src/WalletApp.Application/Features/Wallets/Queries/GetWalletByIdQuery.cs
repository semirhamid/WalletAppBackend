using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Queries;

public class GetWalletByIdQuery : IRequest<WalletResponseDto>
{
    public Guid Id { get; set; }
}