using MediatR;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Application.Features.Points.Commands;
using WalletApp.Application.Services;

public class CalculateDailyPointsCommandHandler : IRequestHandler<CalculateDailyPointsCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IWalletUserRepository _userRepository;
    private readonly IPointService _pointService;

    public CalculateDailyPointsCommandHandler(
        ITransactionRepository transactionRepository,
        IWalletRepository walletRepository,
        IWalletUserRepository userRepository,
        IPointService pointService)
    {
        _transactionRepository = transactionRepository;
        _walletRepository = walletRepository;
        _userRepository = userRepository;
        _pointService = pointService;
    }

    public async Task<Unit> Handle(CalculateDailyPointsCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        foreach (var user in users)
        {
            var userTransactions = await _transactionRepository.GetRecentTransactions(user.Id, cancellationToken);
            var dailyPoints = _pointService.CalculatePoints(userTransactions, request.Date);
            await _walletRepository.UpdateUserPointsAsync(user.Id, dailyPoints, cancellationToken);
            
        }

        return Unit.Value;
    }
}