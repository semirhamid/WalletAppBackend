using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, TransactionDTO>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public CreateTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<TransactionDTO> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = _mapper.Map<Transaction>(request);

        await _transactionRepository.AddAsync(transaction, cancellationToken);
        return _mapper.Map<TransactionDTO>(transaction);
    }
}