using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Transactions.Commands;

public class UpdateTransactionCommand : IRequest
{
    public UpdateTransationDto Transation { get; set; }

    public UpdateTransactionCommand(UpdateTransationDto transation)
    {
        Transation = transation;
    }
}