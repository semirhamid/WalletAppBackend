using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application.Features.Transactions.Queries;

public class GetTransactionByIdQuery : IRequest<TransactionResponseDto>
{
    public Guid Id { get; set; }
}