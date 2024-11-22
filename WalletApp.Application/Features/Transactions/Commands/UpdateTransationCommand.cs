using MediatR;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Transactions.Commands;

public class UpdateTransactionCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public TransationStatus Status { get; set; }
    public Guid UserId { get; set; }
}