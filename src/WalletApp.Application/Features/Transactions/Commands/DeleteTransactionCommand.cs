using MediatR;

namespace WalletApp.Application.Features.Transactions.Commands;

public class DeleteTransactionCommand : IRequest
{
    public Guid Id { get; set; }
}