using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Queries;

public class GetWalletQuery : IRequest<List<WalletResponseDto>>
{
}