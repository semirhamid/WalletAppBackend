using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Commands;

public class CreateWalletCommand : IRequest<WalletDto>
{
    public Guid UserId { get; set; }
    public decimal CurrentBalance { get; set; }
    public int TotalPoints { get; set; }
}