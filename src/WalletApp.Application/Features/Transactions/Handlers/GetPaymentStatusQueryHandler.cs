using MediatR;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Application.Features.Transactions.Queries;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusQuery, (string message, decimal amountLeft)>
{
    private readonly ITransactionRepository _transactionRepository;

    public GetPaymentStatusQueryHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<(string message, decimal amountLeft)> Handle(GetPaymentStatusQuery request, CancellationToken cancellationToken)
    {
        // Calculate the amount left for the current month
        var amountLeft = await _transactionRepository.GetAmountLeftForMonth(request.UserId, request.MonthlyTarget, cancellationToken);

        if (amountLeft == null)
        {
            return ("No transactions found for this user.", 0);
        }

        if (amountLeft == 0)
        {
            var currentMonth = DateTime.Now.ToString("MMMM");
            return ($"You've paid your {currentMonth}", amountLeft);
        }

        return ($"You still need to pay ${amountLeft} this month.", amountLeft);
    }
}
