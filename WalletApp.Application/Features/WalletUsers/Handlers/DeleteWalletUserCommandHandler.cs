using MediatR;
using WalletApp.Application.Features.WalletUser.Commands;
using WalletApp.Application.Contracts.Persistence;

namespace WalletApp.Application.Features.WalletUser.Handlers;

public class DeleteWalletUserCommandHandler : IRequestHandler<DeleteWalletUserCommand>
{
    private readonly IWalletUserRepository _userRepository;

    public DeleteWalletUserCommandHandler(IWalletUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteWalletUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
        {
            throw new ApplicationException($"User with id {request.Id} not found");
        }

        await _userRepository.DeleteAsync(user.Id, cancellationToken);
        return Unit.Value;
    }
}