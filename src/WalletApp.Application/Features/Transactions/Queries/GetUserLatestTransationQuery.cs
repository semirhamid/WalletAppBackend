using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application.Features.Transactions.Queries;

public class GetUserLatestTransactionQuery : IRequest<List<TransactionResponseDto>>
{
    public Guid UserId { get; set; }
}