using AutoMapper;
using MediatR;
using WalletApp.Application.Features.Transactions.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public UpdateTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = _mapper.Map<Transaction>(request);
        await _transactionRepository.UpdateAsync(transaction, cancellationToken);
        return Unit.Value;
    }
}