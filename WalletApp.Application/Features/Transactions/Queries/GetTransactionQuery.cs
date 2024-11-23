using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application.Features.Transactions.Queries;

public class GetTransactionQuery : IRequest<List<TransactionResponseDto>>
{
}