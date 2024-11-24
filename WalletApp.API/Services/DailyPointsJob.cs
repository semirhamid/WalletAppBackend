using MediatR;
using WalletApp.Application.Features.Points.Commands;

namespace WalletApp.API.Services;

public class DailyPointsJob : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public DailyPointsJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var today = DateTime.UtcNow.Date;

                // Send the command within the scoped context
                await mediator.Send(new CalculateDailyPointsCommand { Date = today }, stoppingToken);
            }

            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}