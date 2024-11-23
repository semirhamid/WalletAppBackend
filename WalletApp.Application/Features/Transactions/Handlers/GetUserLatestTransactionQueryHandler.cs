using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Queries;
using WalletApp.Application.Persistence.Contract;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class GetUserLatestTransactionQueryHandler : IRequestHandler<GetUserLatestTransactionQuery, List<TransactionResponseDto>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetUserLatestTransactionQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<List<TransactionResponseDto>> Handle(GetUserLatestTransactionQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.GetRecentTransactions(request.UserId, cancellationToken);
        return _mapper.Map<List<TransactionResponseDto>>(transactions);
    }
}