using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application.Features.Transactions.Queries;

public class GetTransactionByIdQuery : IRequest<TransactionDTO>
{
    public Guid Id { get; set; }
}