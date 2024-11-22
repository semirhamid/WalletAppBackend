using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Commands;

public class UpdateWalletCommand : IRequest<WalletDto>
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
}