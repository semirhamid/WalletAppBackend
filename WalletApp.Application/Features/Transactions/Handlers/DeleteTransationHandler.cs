using MediatR;
using WalletApp.Application.Features.Transactions.Commands;
using WalletApp.Application.Persistence.Contract;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;

    public DeleteTransactionHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        await _transactionRepository.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}