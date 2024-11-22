using MediatR;

namespace WalletApp.Application.Features.Wallets.Commands;

public class DeleteWalletCommand : IRequest
{
    public Guid Id { get; set; }
}