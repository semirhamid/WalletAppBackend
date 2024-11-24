using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application.Features.Transactions.Queries;

public class GetPaymentStatusQuery : IRequest<(string message, decimal amountLeft)>
{
    public Guid UserId { get; set; }
    public decimal MonthlyTarget { get; set; }
}