using MediatR;
using WalletApp.Application.Features.Points.Commands;

namespace WalletApp.API.Services;

public class DailyPointsJob : BackgroundService
{
    private readonly IMediator _mediator;

    public DailyPointsJob(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var today = DateTime.UtcNow.Date;
            await _mediator.Send(new CalculateDailyPointsCommand { Date = today }, stoppingToken);
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}
