using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Queries;
using WalletApp.Application.Persistence.Contract;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDTO>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<TransactionDTO> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetTransactionById(request.Id, cancellationToken);
        return _mapper.Map<TransactionDTO>(transaction);
    }
}