using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application.Features.Transactions.Commands;

public class CreateTransactionCommand : IRequest<TransactionResponseDto>
{
    public CreateTransactionDto Transation { get; set; }

    public CreateTransactionCommand(CreateTransactionDto transation)
    {
        Transation = transation;
    }
}