using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application.Features.Transactions.Commands;

public class CreateTransactionCommand : IRequest<TransactionDTO>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int Type { get; set; }
    public int Status { get; set; }
    public Guid UserId { get; set; }
}