using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Queries;
using WalletApp.Application.Contracts.Persistence;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, List<TransactionResponseDto>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetTransactionQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<List<TransactionResponseDto>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetAllAsync( cancellationToken);
        return _mapper.Map<List<TransactionResponseDto>>(transaction);
    }
}