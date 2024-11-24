using MediatR;

namespace WalletApp.Application.Features.WalletUser.Commands;

public class DeleteWalletUserCommand : IRequest
{
    public Guid Id { get; set; }
}