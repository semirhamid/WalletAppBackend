using MediatR;

namespace WalletApp.Application.Features.Points.Commands;

public class CalculateDailyPointsCommand : IRequest
{
    public DateTime Date { get; set; }
}
