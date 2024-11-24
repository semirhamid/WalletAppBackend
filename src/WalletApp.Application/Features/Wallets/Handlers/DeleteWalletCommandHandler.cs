using MediatR;
using WalletApp.Application.Features.Wallets.Commands;
using WalletApp.Application.Contracts.Persistence;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand>
{
    private readonly IWalletRepository _walletRepository;

    public DeleteWalletCommandHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<Unit> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByIdAsync(request.Id, cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException($"Wallet with id {request.Id} not found");
        }

        await _walletRepository.DeleteAsync(wallet.Id, cancellationToken);
        return Unit.Value;
    }
}